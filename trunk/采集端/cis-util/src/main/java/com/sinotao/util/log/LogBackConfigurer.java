package com.sinotao.util.log;

import java.io.FileNotFoundException;

import xorg.springframework.util.LogbackConfigurer;

public class LogBackConfigurer {
    private String location;

    public void init() throws FileNotFoundException {
        LogbackConfigurer.initLogging(location);
    }
    
    public void init2() throws FileNotFoundException {
        LogbackConfigurer.initLogging2(location);
    }


    public void destory() {
        LogbackConfigurer.shutdownLogging();
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }
}
