package com.sinotao.business.dao;

import java.util.List;

import org.apache.ibatis.annotations.Param;

import tk.mybatis.mapper.common.Mapper;

import com.sinotao.business.dao.entity.ClinicarCheckItem;

public interface ClinicarCheckItemDao extends Mapper<ClinicarCheckItem> {

	public List<ClinicarCheckItem> selectByCheckNumberAndDptCode(
			@Param("checkNumber") String checkNumber,
			@Param("dptCode") String dptCode);
}
