package com.sinotao.util.spring;

import javax.servlet.ServletContext;

import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import org.springframework.web.context.ServletContextAware;

/**
 * 
 * 功能描述: 以静态变量保存Spring ApplicationContext, 可在任何代码任何地方任何时候中取出ApplicaitonContext.
 * 
 * @version 1.0.0
 * @author tonglei
 */
public class SpringContextHolder implements ApplicationContextAware, ServletContextAware {
    
    private static ApplicationContext applicationContext;
    
    private static ServletContext servletContext;

    /**
     * 实现ApplicationContextAware接口的context注入函数, 将其存入静态变量.
     */
    public void setApplicationContext(ApplicationContext applicationContext) {
        SpringContextHolder.applicationContext = applicationContext; // NOSONAR
    }

    /**
     * 取得存储在静态变量中的ApplicationContext.
     */
    public static ApplicationContext getApplicationContext() {
        checkApplicationContext();
        return applicationContext;
    }

    /**
     * 清除applicationContext静态变量.
     */
    public static void cleanApplicationContext() {
        applicationContext = null;
    }

    private static void checkApplicationContext() {
        if (applicationContext == null) {
            throw new IllegalStateException("applicaitonContext未注入,请在applicationContext.xml中定义SpringContextHolder");
        }
    }

    /**
     * 从静态变量ApplicationContext中取得Bean, 自动转型为所赋值对象的类型.
     */
    @SuppressWarnings("unchecked")
    public static <T> T getBean(String name) {
        checkApplicationContext();
        return (T) applicationContext.getBean(name);
    }

    /**
     * 从静态变量ApplicationContext中取得Bean, 自动转型为所赋值对象的类型.
     */
    public static <T> T getBean(Class<T> clazz) {
        checkApplicationContext();
        return applicationContext.getBean(clazz);
    }
    

    /**
     * 实现ServletContextAware接口的context注入函数, 将其存入静态变量.
     */
    public void setServletContext(ServletContext servletContext) {
        SpringContextHolder.servletContext = servletContext;
    }

    /**
     * 取得存储在静态变量中的servletContext.
     */
    public static ServletContext getServletContext() {
        checkServletContext();
        return servletContext;
    }

    /**
     * 清除servletContext静态变量.
     */
    public static void cleanServletContext() {
        servletContext = null;
    }

    private static void checkServletContext() {
        if (servletContext == null) {
            throw new IllegalStateException("servletContext未注入,请在servletContext.xml中定义SpringContextHolder");
        }
    }
    
    public static String getAppAbsolutPath(){
        return servletContext.getRealPath("/");
    }
}
