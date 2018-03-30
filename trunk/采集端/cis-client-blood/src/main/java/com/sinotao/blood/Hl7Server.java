package com.sinotao.blood;

import java.io.IOException;
import java.util.Map;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import ca.uhn.hl7v2.DefaultHapiContext;
import ca.uhn.hl7v2.HL7Exception;
import ca.uhn.hl7v2.HapiContext;
import ca.uhn.hl7v2.app.Connection;
import ca.uhn.hl7v2.app.ConnectionListener;
import ca.uhn.hl7v2.app.HL7Service;
import ca.uhn.hl7v2.model.Message;
import ca.uhn.hl7v2.model.v231.message.ORU_R01;
import ca.uhn.hl7v2.protocol.ReceivingApplication;
import ca.uhn.hl7v2.protocol.ReceivingApplicationException;
import ca.uhn.hl7v2.protocol.ReceivingApplicationExceptionHandler;

public class Hl7Server {

	private final static Logger logger = LoggerFactory.getLogger(Hl7Server.class);

	private int port = 5100;
	private HapiContext context;
	private HL7Service server;

	public Hl7Server(int _port) {
		this.port = _port;
		this.init();
	}

	private void init() {
		// 初始化HL7
		this.initHL7Server();
	}

	private void initHL7Server() {
		/*
		 * Before we can send, let's create a server to listen for incoming
		 * messages. The following section of code establishes a server
		 * listening on port 1011 for new connections, and then "handles" them
		 * by
		 */
		boolean useTls = false; // Should we use TLS/SSL?
		this.context = new DefaultHapiContext();
		this.server = this.context.newServer(port, useTls);

		/*
		 * The server may have any number of "application" objects registered to
		 * handle messages. We are going to create an application to listen to
		 * ORU^R01 messages.
		 * 
		 * You might want to look at the source of ExampleReceiverApplication
		 * (it's a nested class below) to see how it works.
		 */
		ReceivingApplication handler = new MyReceiverApplication();
		this.server.registerApplication("ORU", "R01", handler); //处理ORU^R01这类数据

		/*
		 * We are going to register the same application to handle ADT^A02
		 * messages. Of course, we coud just as easily have specified a
		 * different handler.
		 * 
		 * this.server.registerApplication("ADT", "A02", handler);
		 */

		/*
		 * Another option would be to specify a single application to handle all
		 * messages, like this:
		 * 
		 * server.registerApplication("*", "*", handler);
		 */

		/*
		 * If you want to be notified any time a new connection comes in or is
		 * lost, you might also want to register a connection listener (see the
		 * bottom of this class to see what the listener looks like). It's fine
		 * to skip this step.
		 */
		this.server.registerConnectionListener(new MyConnectionListener());

		/*
		 * If you want to be notified any processing failures when receiving,
		 * processing, or responding to messages with the server, you can also
		 * register an exception handler. (See the bottom of this class to see
		 * what the listener looks like. ) It's also fine to skip this step, in
		 * which case exceptions will simply be logged.
		 */
		this.server.setExceptionHandler(new MyExceptionHandler());
	}

	/**
	 * Application class for receiving ORU^R01 messages
	 */
	public static class MyReceiverApplication implements ReceivingApplication {
		/**
		 * {@inheritDoc}
		 */
		public boolean canProcess(Message theIn) {
			return true;
		}
	
		/**
		 * {@inheritDoc}
		 */
		public Message processMessage(Message theMessage,
				Map<String, Object> theMetadata)
				throws ReceivingApplicationException, HL7Exception {
	
			@SuppressWarnings("resource")
			String encodedMessage = new DefaultHapiContext().getPipeParser().encode(theMessage);
			logger.info("收到的消息：\n" + encodedMessage + "\n\n");
			ORU_R01 msg = (ORU_R01)theMessage;
			com.sinotao.Main.task.addData(msg);
			
			// Now generate a simple acknowledgment message and return it
			try {
				return theMessage.generateACK();
			} catch (IOException e) {
				logger.error(e.getMessage(), e);
				throw new HL7Exception(e);
			}
		}
	}

	/**
	 * Connection listener which is notified whenever a new connection comes in
	 * or is lost
	 */
	public static class MyConnectionListener implements ConnectionListener {
		public void connectionReceived(Connection theC) {
			logger.info("New connection received: "
					+ theC.getRemoteAddress().toString());
		}
		public void connectionDiscarded(Connection theC) {
			logger.info("Lost connection from: "
					+ theC.getRemoteAddress().toString());
		}

	}

	/**
	 * Exception handler which is notified any time
	 */
	public static class MyExceptionHandler implements
			ReceivingApplicationExceptionHandler {

		/**
		 * Process an exception.
		 * 
		 * @param theIncomingMessage
		 *            the incoming message. This is the raw message which was
		 *            received from the external system
		 * @param theIncomingMetadata
		 *            Any metadata that accompanies the incoming message. See
		 *            {@link ca.uhn.hl7v2.protocol.Transportable#getMetadata()}
		 * @param theOutgoingMessage
		 *            the outgoing message. The response NAK message generated
		 *            by HAPI.
		 * @param theE
		 *            the exception which was received
		 * @return The new outgoing message. This can be set to the value
		 *         provided by HAPI in <code>outgoingMessage</code>, or may be
		 *         replaced with another message. <b>This method may not return
		 *         <code>null</code></b>.
		 */
		public String processException(String theIncomingMessage,
				Map<String, Object> theIncomingMetadata,
				String theOutgoingMessage, Exception theE) throws HL7Exception {
			/*
			 * Here you can do any processing you like. If you want to change
			 * the response (NAK) message which will be returned you may do so,
			 * or just return the NAK which HAPI already created
			 * (theOutgoingMessage)
			 */
			return theOutgoingMessage;
		}
	}

	public boolean start() {
		boolean isStart = false;
		try {
			// Start the server listening for messages
			server.startAndWait();
			isStart = true;
		} catch (InterruptedException e) {
			logger.error(e.getMessage(), e);
		}
		return isStart;
	}

	public void stop() {
		// Stop the receiving server and client
		this.server.stopAndWait();
		try {
			this.context.close();
		} catch (IOException e) {
			logger.error(e.getMessage(), e);
		}
	}
}
