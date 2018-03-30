package com.sinotao.util.buffer;

import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.io.IOException;

public class ByteBuffer {

	public byte[] elems;
	public int length;

	public ByteBuffer() {
		this(64);
	}

	public ByteBuffer(int paramInt) {
		this.elems = new byte[paramInt];
		this.length = 0;
	}

	private void copy(int paramInt) {
		byte[] arrayOfByte = new byte[paramInt];
		System.arraycopy(this.elems, 0, arrayOfByte, 0, this.elems.length);
		this.elems = arrayOfByte;
	}

	public void appendByte(int paramInt) {
		if (this.length >= this.elems.length)
			copy(this.elems.length * 2);
		this.elems[(this.length++)] = (byte) paramInt;
	}

	public void appendBytes(byte[] paramArrayOfByte, int paramInt1,
			int paramInt2) {
		while (this.length + paramInt2 > this.elems.length)
			copy(this.elems.length * 2);
		System.arraycopy(paramArrayOfByte, paramInt1, this.elems, this.length, paramInt2);
		this.length += paramInt2;
	}

	public void appendBytes(byte[] paramArrayOfByte) {
		appendBytes(paramArrayOfByte, 0, paramArrayOfByte.length);
	}

	public void appendChar(int paramInt) {
		while (this.length + 1 >= this.elems.length)
			copy(this.elems.length * 2);
		this.elems[this.length] = (byte) (paramInt >> 8 & 0xFF);
		this.elems[(this.length + 1)] = (byte) (paramInt & 0xFF);
		this.length += 2;
	}

	public void appendInt(int paramInt) {
		while (this.length + 3 >= this.elems.length)
			copy(this.elems.length * 2);
		this.elems[this.length] = (byte) (paramInt >> 24 & 0xFF);
		this.elems[(this.length + 1)] = (byte) (paramInt >> 16 & 0xFF);
		this.elems[(this.length + 2)] = (byte) (paramInt >> 8 & 0xFF);
		this.elems[(this.length + 3)] = (byte) (paramInt & 0xFF);
		this.length += 4;
	}

	public void appendLong(long paramLong) {
		ByteArrayOutputStream localByteArrayOutputStream = new ByteArrayOutputStream(8);
		DataOutputStream localDataOutputStream = new DataOutputStream(localByteArrayOutputStream);
		try {
			localDataOutputStream.writeLong(paramLong);
			appendBytes(localByteArrayOutputStream.toByteArray(), 0, 8);
		} catch (IOException localIOException) {
			throw new AssertionError("write");
		}
	}

	public void appendFloat(float paramFloat) {
		ByteArrayOutputStream localByteArrayOutputStream = new ByteArrayOutputStream(4);
		DataOutputStream localDataOutputStream = new DataOutputStream(localByteArrayOutputStream);
		try {
			localDataOutputStream.writeFloat(paramFloat);
			appendBytes(localByteArrayOutputStream.toByteArray(), 0, 4);
		} catch (IOException localIOException) {
			throw new AssertionError("write");
		}
	}

	public void appendDouble(double paramDouble) {
		ByteArrayOutputStream localByteArrayOutputStream = new ByteArrayOutputStream(8);
		DataOutputStream localDataOutputStream = new DataOutputStream(localByteArrayOutputStream);
		try {
			localDataOutputStream.writeDouble(paramDouble);
			appendBytes(localByteArrayOutputStream.toByteArray(), 0, 8);
		} catch (IOException localIOException) {
			throw new AssertionError("write");
		}
	}

}
