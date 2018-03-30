package com.sinotao.business.dao;

import java.util.List;

import org.apache.ibatis.annotations.Param;

import tk.mybatis.mapper.common.Mapper;

import com.sinotao.business.dao.entity.ClinicarCheckResult;

public interface ClinicarCheckResultDao extends Mapper<ClinicarCheckResult> {

	public String selectLastCheckNumber(@Param("suffix") String suffix,
			@Param("itemCode") List<String> itemCode);


	public Integer selectLastCheckItemId(@Param("suffix") String suffix,
			@Param("dptCode") String dptCode);
}
