package com.sinotao.web.listener;

import javax.servlet.ServletContextEvent;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.bridge.SLF4JBridgeHandler;
import org.springframework.web.context.ContextLoaderListener;

public class SystemListener extends ContextLoaderListener {

	private static Logger logger = LoggerFactory.getLogger(SystemListener.class);

	// private static ApplicationContext applicationContext;

	@Override
	public void contextInitialized(ServletContextEvent event) {
		super.contextInitialized(event);
		/******** jul to slf4j *********/
		SLF4JBridgeHandler.install();

		/************* spring *********/
		// applicationContext = super.getCurrentWebApplicationContext();
		logger.debug("systemListener contextInitialized");
	}

	@Override
	public void contextDestroyed(ServletContextEvent event) {
		super.contextDestroyed(event);
		SLF4JBridgeHandler.uninstall();
	}

}
