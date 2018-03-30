package com.sinotao.business.biz;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.sinotao.business.dao.InterfaceDataDao;
import com.sinotao.business.dao.entity.InterfaceData;

@Service
public class InterfaceDataBiz {

	@Autowired
	private InterfaceDataDao interfaceDataDao;
	
	/**
     * 新增
     * @param interfaceData
     * @return
     */
	@Transactional
	public int insert(InterfaceData interfaceData){
		return this.interfaceDataDao.insertSelective(interfaceData);
	}
}
