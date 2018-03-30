/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 100130
 Source Host           : localhost:3306
 Source Schema         : cis_v1.0

 Target Server Type    : MySQL
 Target Server Version : 100130
 File Encoding         : 65001

 Date: 30/03/2018 11:00:22
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for t_clinicar_allcheck
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_allcheck`;
CREATE TABLE `t_clinicar_allcheck`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `check_number` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '检查号',
  `advice` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '医生建议',
  `aduitStatus` bit(1) DEFAULT NULL COMMENT '审核状态',
  `disease` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '病种',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_clinicar_check
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_check`;
CREATE TABLE `t_clinicar_check`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '代理主键',
  `deleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '删除标记',
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '姓名',
  `gender_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '性别编码',
  `gender_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '性别',
  `nationality_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '民族编号',
  `nationality_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '民族',
  `birthday` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '出生日期',
  `age` int(11) DEFAULT NULL COMMENT '年龄',
  `marital_status_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '婚姻状况编码',
  `marital_status_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '婚姻状况',
  `certificate_type_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '证件类型编码',
  `certificate_type_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '证件类型',
  `certificate_number` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '证件号',
  `address` varchar(400) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '地址',
  `tel` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '联系电话',
  `remark` varchar(400) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '备注',
  `check_number` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '检查号',
  `check_doctor` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '开单医生',
  `check_date` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '检查日期（yyyy-MM-dd）',
  `conclusion` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '结论',
  `advice` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '建议',
  `allcheck_completed` bit(1) DEFAULT NULL COMMENT '总检完成',
  `disease` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '病种',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 87 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '检查信息表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_check
-- ----------------------------
INSERT INTO `t_clinicar_check` VALUES (61, b'0', '福田', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180307001', 'ys', '2018-03-07', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (62, b'0', '福田汽车', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180307002', 'ys', '2018-03-07', NULL, NULL, b'1', NULL);
INSERT INTO `t_clinicar_check` VALUES (63, b'0', '福田汽车血液', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180307003', 'ys', '2018-03-07', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (64, b'0', '福田汽车血液004', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180307004', 'ys', '2018-03-07', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (65, b'0', '福田汽车血液005', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180307005', 'ys', '2018-03-07', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (66, b'0', '福田汽车血液006', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180307006', 'ys', '2018-03-07', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (67, b'0', '福田汽车血液007', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180307007', 'ys', '2018-03-07', NULL, NULL, b'1', NULL);
INSERT INTO `t_clinicar_check` VALUES (68, b'0', '心电01', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180307008', 'ys', '2018-03-07', NULL, NULL, b'1', NULL);
INSERT INTO `t_clinicar_check` VALUES (69, b'0', '生化01', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180308001', 'ys', '2018-03-08', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (70, b'0', '生化02', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180308002', 'ys', '2018-03-08', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (71, b'0', '生化03', '2', '女', '', '', '2018-03-07', 23, '2', '未婚', '', '', '', '', '0', '', '180308003', 'ys', '2018-03-08', NULL, NULL, b'1', NULL);
INSERT INTO `t_clinicar_check` VALUES (72, b'0', '福田BC', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180308004', 'ys', '2018-03-08', NULL, NULL, b'1', NULL);
INSERT INTO `t_clinicar_check` VALUES (73, b'0', '福田BC1', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180308005', 'ys', '2018-03-08', NULL, NULL, b'1', NULL);
INSERT INTO `t_clinicar_check` VALUES (74, b'0', '福田BC2', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180309001', 'ys', '2018-03-09', NULL, NULL, b'1', NULL);
INSERT INTO `t_clinicar_check` VALUES (75, b'0', '福田BC3', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180327001', 'ys', '2018-03-27', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (76, b'0', '福田BC4', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180328001', 'ys', '2018-03-28', NULL, '424', b'1', '234');
INSERT INTO `t_clinicar_check` VALUES (77, b'0', '福田BC4', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180328002', 'ys', '2018-03-28', NULL, '3', b'1', '2');
INSERT INTO `t_clinicar_check` VALUES (78, b'0', '福田BC5', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180328003', 'ys', '2018-03-28', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (79, b'0', '福田BC66', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180328004', 'ys', '2018-03-28', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (80, b'0', 'AAAAAAAAAAA', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180329001', 'ys', '2018-03-29', NULL, NULL, b'0', NULL);
INSERT INTO `t_clinicar_check` VALUES (81, b'0', 'BBBBBBBBBB', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180329002', 'ys', '2018-03-29', NULL, '1222323424', b'1', '2332');
INSERT INTO `t_clinicar_check` VALUES (82, b'0', 'CCCCCCC', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180329003', 'ys', '2018-03-29', NULL, '3', b'1', '2');
INSERT INTO `t_clinicar_check` VALUES (83, b'0', 'DDDDDDDD', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180329004', 'ys', '2018-03-29', NULL, '', b'1', '');
INSERT INTO `t_clinicar_check` VALUES (84, b'0', 'EEEEEEE', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180329005', 'ys', '2018-03-29', NULL, '', b'1', '');
INSERT INTO `t_clinicar_check` VALUES (85, b'0', 'FFFFFF', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180329006', 'ys', '2018-03-29', NULL, '', b'1', '');
INSERT INTO `t_clinicar_check` VALUES (86, b'0', 'GGGGGGG', '1', '男', '1', '汉族', '1990-03-07', 20, '3', '已婚', '1', '身份证', '213123123123', '', '1355555555', '', '180329007', 'ys', '2018-03-29', NULL, '', b'1', '');

-- ----------------------------
-- Table structure for t_clinicar_check_item
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_check_item`;
CREATE TABLE `t_clinicar_check_item`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '代理主键',
  `deleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '删除标记',
  `check_id` int(11) NOT NULL,
  `item_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查项目编号',
  `item_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查项目',
  `dpt_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '科室编号',
  `dpt_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '科室',
  `completed` bit(1) DEFAULT NULL COMMENT '该项检查是否完成',
  `canceled` bit(1) DEFAULT NULL COMMENT '弃检',
  `summary` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '小结',
  `conclusion` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '结论',
  `advice` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '建议',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 157 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '检查项目信息表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_check_item
-- ----------------------------
INSERT INTO `t_clinicar_check_item` VALUES (116, b'0', 61, '2388', '尿常规', '605', '尿分析仪', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (117, b'0', 62, '2388', '尿常规', '605', '尿分析仪', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (118, b'0', 63, '2391', '血常规', '603', '血细胞分析仪', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (119, b'0', 64, '2391', '血常规', '603', '血细胞分析仪', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (120, b'0', 65, '2391', '血常规', '603', '血细胞分析仪', b'1', b'0', '1、结果低于参考范围下限\n2、正常\n3、正常\n4、结果低于参考范围下限\n5、结果低于参考范围下限\n6、正常\n7、正常\n8、正常\n9、正常\n10、正常\n11、结果低于参考范围下限\n12、结果低于参考范围下限\n13、正常\n14、正常\n15、正常\n16、正常\n17、正常\n18、正常\n19、正常\n', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (121, b'0', 66, '2391', '血常规', '603', '血细胞分析仪', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (122, b'0', 67, '2391', '血常规', '603', '血细胞分析仪', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (123, b'0', 68, '1683', '心电图', '540', '心电图', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (124, b'0', 69, '2389', '生化全项', '604', '生化分析仪', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (125, b'0', 70, '2389', '生化全项', '604', '生化分析仪', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (126, b'0', 71, '2389', '生化全项', '604', '生化分析仪', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (127, b'0', 72, '2387', '浅表淋巴结彩超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (128, b'0', 73, '2385', '甲状腺彩超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (129, b'0', 74, '2383', '心脏彩超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (130, b'0', 75, '2357', '双侧腕关节正侧位', '529', 'X光', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (131, b'0', 76, '2357', '双侧腕关节正侧位', '529', 'X光', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (132, b'0', 77, '2390', '电子阴道镜', '606', '电子阴道镜', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (133, b'0', 78, '2390', '电子阴道镜', '606', '电子阴道镜', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (134, b'0', 78, '2357', '双侧腕关节正侧位', '529', 'X光', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (135, b'0', 79, '2356', '双侧尺桡骨正侧位', '529', 'X光', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (136, b'1', 79, '2389', '生化全项', '604', '生化分析仪', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (137, b'0', 79, '2390', '电子阴道镜', '606', '电子阴道镜', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (138, b'0', 80, '2390', '电子阴道镜', '606', '电子阴道镜', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (139, b'0', 80, '2357', '双侧腕关节正侧位', '529', 'X光', b'0', b'0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (140, b'0', 81, '2385', '甲状腺彩超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (141, b'0', 81, '2390', '电子阴道镜', '606', '电子阴道镜', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (142, b'0', 81, '2357', '双侧腕关节正侧位', '529', 'X光', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (143, b'0', 82, '2390', '电子阴道镜', '606', '电子阴道镜', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (144, b'0', 82, '2355', '双侧肘关节正位', '529', 'X光', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (145, b'0', 83, '2390', '电子阴道镜', '606', '电子阴道镜', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (146, b'0', 83, '2387', '浅表淋巴结彩超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (147, b'0', 83, '2355', '双侧肘关节正位', '529', 'X光', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (148, b'0', 84, '2390', '电子阴道镜', '606', '电子阴道镜', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (149, b'0', 84, '2381', '前列腺彩超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (150, b'0', 84, '2356', '双侧尺桡骨正侧位', '529', 'X光', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (151, b'0', 85, '2390', '电子阴道镜', '606', '电子阴道镜', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (152, b'0', 85, '2379', '妇科彩超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (153, b'0', 85, '2356', '双侧尺桡骨正侧位', '529', 'X光', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (154, b'0', 86, '2390', '电子阴道镜', '606', '电子阴道镜', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (155, b'0', 86, '2378', '泌尿系超', '510', 'B超', b'1', b'0', '', NULL, NULL);
INSERT INTO `t_clinicar_check_item` VALUES (156, b'0', 86, '2356', '双侧尺桡骨正侧位', '529', 'X光', b'1', b'0', '', NULL, NULL);

-- ----------------------------
-- Table structure for t_clinicar_check_result
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_check_result`;
CREATE TABLE `t_clinicar_check_result`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '代理主键',
  `deleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '删除标记',
  `create_time` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP(0) COMMENT '记录创建时间',
  `check_number` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '检查号',
  `item_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查项目编号',
  `item_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查项目名称',
  `item_detail_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '明细项代码',
  `item_detail_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '明细项名称',
  `result` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '项目检查结果',
  `unit` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '项目单位',
  `conclusion` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '结论',
  `attachment_path` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '附件地址',
  `references_range` varchar(90) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '检验结果范围，形式如：“参考范围下限-参考范围上限”，或“<参考范围上限”，或“>参考范围下限”。',
  `dpt_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '科室编码',
  `dpt_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '科室名称',
  `report_path` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '报告地址',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 822 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '检查结果表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_check_result
-- ----------------------------
INSERT INTO `t_clinicar_check_result` VALUES (684, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'LEU', 'LEU', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (685, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'NIT', 'NIT', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (686, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'URO', 'URO', 'norm.      ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (687, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'PRO', 'PRO', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (688, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'PH', 'PH', '6.5        ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (689, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'BLD', 'BLD', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (690, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'SG', 'SG', '1.005      ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (691, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'KET', 'KET', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (692, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'BIL', 'BIL', '1+         ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (693, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'GLU', 'GLU', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (694, b'0', '2018-03-07 13:26:32', '180307001', '2388', '尿常规', 'ASC', 'ASC', '3+         ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (695, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'LEU', 'LEU', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (696, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'NIT', 'NIT', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (697, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'URO', 'URO', 'norm.      ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (698, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'PRO', 'PRO', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (699, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'PH', 'PH', '6.5        ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (700, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'BLD', 'BLD', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (701, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'SG', 'SG', '1.005      ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (702, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'KET', 'KET', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (703, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'BIL', 'BIL', '1+         ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (704, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'GLU', 'GLU', '-          ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (705, b'0', '2018-03-07 13:34:19', '180307002', '2388', '尿常规', 'ASC', 'ASC', '3+         ', '', '', '', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (706, b'0', '2018-03-07 17:29:41', '180307003', '2391', '血常规', '08001', 'Take Mode', 'O', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (707, b'0', '2018-03-07 17:29:41', '180307003', '2391', '血常规', '08002', 'Blood Mode', 'W', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (708, b'0', '2018-03-07 17:29:41', '180307003', '2391', '血常规', '01002', 'Ref Group', '通用', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (709, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '6690-2', 'WBC', '0.0', '10*9/L', '结果低于参考范围下限', '', '4.0-10.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (710, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '731-0', 'LYM#', '*****', '10*9/L', '正常', '', '0.8-4.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (711, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '736-9', 'LYM%', '*****', '%', '正常', '', '20.0-40.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (712, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '789-8', 'RBC', '0.00', '10*12/L', '结果低于参考范围下限', '', '3.50-5.50', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (713, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '718-7', 'HGB', '0', 'g/L', '结果低于参考范围下限', '', '110-160', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (714, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '787-2', 'MCV', '*****', 'fL', '正常', '', '80.0-100.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (715, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '785-6', 'MCH', '*****', 'pg', '正常', '', '27.0-34.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (716, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '786-4', 'MCHC', '*****', 'g/L', '正常', '', '320-360', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (717, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '788-0', 'RDW-CV', '*****', '%', '正常', '', '11.0-16.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (718, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '21000-5', 'RDW-SD', '*****', 'fL', '正常', '', '35.0-56.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (719, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '4544-3', 'HCT', '0.0', '%', '结果低于参考范围下限', '', '37.0-54.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (720, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '777-3', 'PLT', '1', '10*9/L', '结果低于参考范围下限', '', '100-300', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (721, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '32623-1', 'MPV', '*****', 'fL', '正常', '', '6.5-12.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (722, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '32207-3', 'PDW', '*****', '', '正常', '', '15.0-17.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (723, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '10002', 'PCT', '*****', '%', '正常', '', '0.108-0.282', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (724, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '10027', 'MID#', '*****', '10*9/L', '正常', '', '0.1-1.5', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (725, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '10029', 'MID%', '*****', '%', '正常', '', '3.0-15.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (726, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '10028', 'GRAN#', '*****', '10*9/L', '正常', '', '2.0-7.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (727, b'0', '2018-03-07 17:35:13', '180307003', '2391', '血常规', '10030', 'GRAN%', '*****', '%', '正常', '', '50.0-70.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (728, b'0', '2018-03-07 17:38:26', '180307005', '2391', '血常规', '08001', 'Take Mode', 'O', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (729, b'0', '2018-03-07 17:38:26', '180307005', '2391', '血常规', '08002', 'Blood Mode', 'W', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (730, b'0', '2018-03-07 17:38:26', '180307005', '2391', '血常规', '01002', 'Ref Group', '通用', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (731, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '6690-2', 'WBC', '0.0', '10*9/L', '结果低于参考范围下限', '', '4.0-10.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (732, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '731-0', 'LYM#', '*****', '10*9/L', '正常', '', '0.8-4.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (733, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '736-9', 'LYM%', '*****', '%', '正常', '', '20.0-40.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (734, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '789-8', 'RBC', '0.00', '10*12/L', '结果低于参考范围下限', '', '3.50-5.50', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (735, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '718-7', 'HGB', '1', 'g/L', '结果低于参考范围下限', '', '110-160', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (736, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '787-2', 'MCV', '*****', 'fL', '正常', '', '80.0-100.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (737, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '785-6', 'MCH', '*****', 'pg', '正常', '', '27.0-34.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (738, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '786-4', 'MCHC', '*****', 'g/L', '正常', '', '320-360', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (739, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '788-0', 'RDW-CV', '*****', '%', '正常', '', '11.0-16.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (740, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '21000-5', 'RDW-SD', '*****', 'fL', '正常', '', '35.0-56.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (741, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '4544-3', 'HCT', '0.0', '%', '结果低于参考范围下限', '', '37.0-54.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (742, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '777-3', 'PLT', '1', '10*9/L', '结果低于参考范围下限', '', '100-300', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (743, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '32623-1', 'MPV', '*****', 'fL', '正常', '', '6.5-12.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (744, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '32207-3', 'PDW', '*****', '', '正常', '', '15.0-17.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (745, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '10002', 'PCT', '*****', '%', '正常', '', '0.108-0.282', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (746, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '10027', 'MID#', '*****', '10*9/L', '正常', '', '0.1-1.5', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (747, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '10029', 'MID%', '*****', '%', '正常', '', '3.0-15.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (748, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '10028', 'GRAN#', '*****', '10*9/L', '正常', '', '2.0-7.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (749, b'0', '2018-03-07 17:38:48', '180307005', '2391', '血常规', '10030', 'GRAN%', '*****', '%', '正常', '', '50.0-70.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (750, b'0', '2018-03-07 18:57:19', '180307007', '2391', '血常规', '08001', 'Take Mode', 'O', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (751, b'0', '2018-03-07 18:57:19', '180307007', '2391', '血常规', '08002', 'Blood Mode', 'W', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (752, b'0', '2018-03-07 18:57:19', '180307007', '2391', '血常规', '01002', 'Ref Group', '通用', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (753, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '6690-2', 'WBC', '0.0', '10*9/L', '结果低于参考范围下限', '', '4.0-10.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (754, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '731-0', 'LYM#', '*****', '10*9/L', '正常', '', '0.8-4.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (755, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '736-9', 'LYM%', '*****', '%', '正常', '', '20.0-40.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (756, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '789-8', 'RBC', '0.00', '10*12/L', '结果低于参考范围下限', '', '3.50-5.50', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (757, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '718-7', 'HGB', '1', 'g/L', '结果低于参考范围下限', '', '110-160', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (758, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '787-2', 'MCV', '*****', 'fL', '正常', '', '80.0-100.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (759, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '785-6', 'MCH', '*****', 'pg', '正常', '', '27.0-34.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (760, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '786-4', 'MCHC', '*****', 'g/L', '正常', '', '320-360', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (761, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '788-0', 'RDW-CV', '*****', '%', '正常', '', '11.0-16.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (762, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '21000-5', 'RDW-SD', '*****', 'fL', '正常', '', '35.0-56.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (763, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '4544-3', 'HCT', '0.0', '%', '结果低于参考范围下限', '', '37.0-54.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (764, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '777-3', 'PLT', '2', '10*9/L', '结果低于参考范围下限', '', '100-300', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (765, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '32623-1', 'MPV', '*****', 'fL', '正常', '', '6.5-12.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (766, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '32207-3', 'PDW', '*****', '', '正常', '', '15.0-17.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (767, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '10002', 'PCT', '*****', '%', '正常', '', '0.108-0.282', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (768, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '10027', 'MID#', '*****', '10*9/L', '正常', '', '0.1-1.5', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (769, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '10029', 'MID%', '*****', '%', '正常', '', '3.0-15.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (770, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '10028', 'GRAN#', '*****', '10*9/L', '正常', '', '2.0-7.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (771, b'0', '2018-03-07 18:58:08', '180307007', '2391', '血常规', '10030', 'GRAN%', '*****', '%', '正常', '', '50.0-70.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (772, b'0', '2018-03-07 18:58:34', '180307006', '2391', '血常规', '08001', 'Take Mode', 'O', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (773, b'0', '2018-03-07 18:58:34', '180307006', '2391', '血常规', '08002', 'Blood Mode', 'W', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (774, b'0', '2018-03-07 18:58:34', '180307006', '2391', '血常规', '01002', 'Ref Group', '通用', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (775, b'0', '2018-03-07 20:21:50', '180307006', '2391', '血常规', '6690-2', 'WBC', '0.0', '10*9/L', '结果低于参考范围下限', '', '4.0-10.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (776, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '731-0', 'LYM#', '*****', '10*9/L', '正常', '', '0.8-4.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (777, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '736-9', 'LYM%', '*****', '%', '正常', '', '20.0-40.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (778, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '789-8', 'RBC', '0.00', '10*12/L', '结果低于参考范围下限', '', '3.50-5.50', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (779, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '718-7', 'HGB', '1', 'g/L', '结果低于参考范围下限', '', '110-160', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (780, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '787-2', 'MCV', '*****', 'fL', '正常', '', '80.0-100.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (781, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '785-6', 'MCH', '*****', 'pg', '正常', '', '27.0-34.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (782, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '786-4', 'MCHC', '*****', 'g/L', '正常', '', '320-360', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (783, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '788-0', 'RDW-CV', '*****', '%', '正常', '', '11.0-16.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (784, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '21000-5', 'RDW-SD', '*****', 'fL', '正常', '', '35.0-56.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (785, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '4544-3', 'HCT', '0.0', '%', '结果低于参考范围下限', '', '37.0-54.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (786, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '777-3', 'PLT', '2', '10*9/L', '结果低于参考范围下限', '', '100-300', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (787, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '32623-1', 'MPV', '*****', 'fL', '正常', '', '6.5-12.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (788, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '32207-3', 'PDW', '*****', '', '正常', '', '15.0-17.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (789, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '10002', 'PCT', '*****', '%', '正常', '', '0.108-0.282', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (790, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '10027', 'MID#', '*****', '10*9/L', '正常', '', '0.1-1.5', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (791, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '10029', 'MID%', '*****', '%', '正常', '', '3.0-15.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (792, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '10028', 'GRAN#', '*****', '10*9/L', '正常', '', '2.0-7.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (793, b'0', '2018-03-07 18:58:42', '180307006', '2391', '血常规', '10030', 'GRAN%', '*****', '%', '正常', '', '50.0-70.0', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (794, b'0', '2018-03-07 20:32:44', '180307008', '1683', '心电图', NULL, NULL, NULL, NULL, NULL, 'heartFolder\\data\\20180307203244_478\\180307008_20180307202714.pdf', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (795, b'0', '2018-03-08 17:24:51', '180308003', '2389', '生化全项', 'ALT1', 'ALT1', '-0.000397', 'mmol/L', '正常', '', '-', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (796, b'0', '2018-03-08 17:24:51', '180308003', '2389', '生化全项', 'AST1', 'AST1', '0.000117', 'mmol/L', '正常', '', '-', NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (797, b'0', '2018-03-08 17:47:59', '180308004', '2387', '浅表淋巴结彩超', NULL, NULL, NULL, NULL, NULL, 'bc\\data\\180308004\\20180308_174831_0.jpeg', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (798, b'0', '2018-03-08 18:52:06', '180308005', '2385', '甲状腺彩超', NULL, NULL, NULL, NULL, NULL, 'bc\\data\\180308005\\20180308_185259_2.jpeg', NULL, NULL, NULL, NULL);
INSERT INTO `t_clinicar_check_result` VALUES (799, b'0', '2018-03-09 10:17:28', '180309001', '2383', '心脏彩超', NULL, NULL, NULL, NULL, NULL, 'bc\\data\\180309001\\20180309_101410_0.jpeg', NULL, NULL, NULL, 'bc\\data\\180309001\\Report_Cardiac.html');
INSERT INTO `t_clinicar_check_result` VALUES (800, b'0', '2018-03-28 12:21:34', '180328001', '2357', '双侧腕关节正侧位', NULL, NULL, NULL, NULL, NULL, 'xRayFolder\\data\\180328001\\Image1.png', NULL, NULL, NULL, 'xRayFolder\\data\\180328001\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (801, b'0', '2018-03-28 12:19:33', '180328002', '2390', '电子阴道镜', NULL, NULL, NULL, NULL, NULL, 'ydj\\data\\180328002\\201803272137.pdf', NULL, NULL, NULL, '');
INSERT INTO `t_clinicar_check_result` VALUES (803, b'0', '2018-03-29 08:56:40', '180329001', '2357', '双侧腕关节正侧位', NULL, NULL, NULL, NULL, NULL, 'xRayFolder\\data\\180329001\\Image1.png', NULL, NULL, NULL, 'xRayFolder\\data\\180329001\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (804, b'0', '2018-03-29 08:59:05', '180329001', '2390', '电子阴道镜', NULL, NULL, NULL, NULL, NULL, 'ydj\\data\\180329001\\201803272137.pdf', NULL, NULL, NULL, '');
INSERT INTO `t_clinicar_check_result` VALUES (808, b'0', '2018-03-29 13:12:39', '180329003', '2355', '双侧肘关节正位', NULL, NULL, NULL, NULL, NULL, 'xRayFolder\\data\\180329003\\Image1.png', NULL, NULL, NULL, 'xRayFolder\\data\\180329003\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (809, b'0', '2018-03-29 13:12:48', '180329003', '2390', '电子阴道镜', NULL, NULL, NULL, NULL, NULL, 'ydj\\data\\180329003\\201803272137.pdf', NULL, NULL, NULL, 'xRayFolder\\data\\180329003\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (810, b'0', '2018-03-29 13:44:08', '180329004', '2355', '双侧肘关节正位', NULL, NULL, NULL, NULL, NULL, 'xRayFolder\\data\\180329004\\Image1.png', NULL, NULL, NULL, 'xRayFolder\\data\\180329004\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (811, b'0', '2018-03-29 13:44:11', '180329004', '2387', '浅表淋巴结彩超', NULL, NULL, NULL, NULL, NULL, 'bc\\data\\180329004\\20180309_101410_0.jpeg', NULL, NULL, NULL, 'bc\\data\\180329004\\Report_Cardiac.html');
INSERT INTO `t_clinicar_check_result` VALUES (812, b'0', '2018-03-29 13:44:18', '180329004', '2390', '电子阴道镜', NULL, NULL, NULL, NULL, NULL, 'ydj\\data\\180329004\\201803272137.pdf', NULL, NULL, NULL, 'bc\\data\\180329004\\Report_Cardiac.html');
INSERT INTO `t_clinicar_check_result` VALUES (813, b'0', '2018-03-29 14:02:52', '180329005', '2356', '双侧尺桡骨正侧位', NULL, NULL, NULL, NULL, NULL, 'xRayFolder\\data\\180329005\\Image1.png', NULL, NULL, NULL, 'xRayFolder\\data\\180329005\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (814, b'0', '2018-03-29 14:02:55', '180329005', '2381', '前列腺彩超', NULL, NULL, NULL, NULL, NULL, 'bc\\data\\180329005\\20180309_101410_0.jpeg', NULL, NULL, NULL, 'bc\\data\\180329005\\Report_Cardiac.html');
INSERT INTO `t_clinicar_check_result` VALUES (815, b'0', '2018-03-29 14:02:56', '180329005', '2390', '电子阴道镜', NULL, NULL, NULL, NULL, NULL, 'ydj\\data\\180329005\\201803272137.pdf', NULL, NULL, NULL, '');
INSERT INTO `t_clinicar_check_result` VALUES (816, b'0', '2018-03-29 15:32:14', '180329006', '2356', '双侧尺桡骨正侧位', NULL, NULL, NULL, NULL, NULL, 'xRayFolder\\data\\180329006\\Image1.png', NULL, NULL, NULL, 'xRayFolder\\data\\180329006\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (817, b'0', '2018-03-29 15:32:20', '180329006', '2379', '妇科彩超', NULL, NULL, NULL, NULL, NULL, 'bc\\data\\180329006\\20180309_101410_0.jpeg', NULL, NULL, NULL, 'bc\\data\\180329006\\Report_Cardiac.html');
INSERT INTO `t_clinicar_check_result` VALUES (818, b'0', '2018-03-29 15:32:24', '180329006', '2390', '电子阴道镜', NULL, NULL, NULL, NULL, NULL, 'ydj\\data\\180329006\\201803272137.pdf', NULL, NULL, NULL, '');
INSERT INTO `t_clinicar_check_result` VALUES (819, b'0', '2018-03-29 15:45:19', '180329007', '2356', '双侧尺桡骨正侧位', NULL, NULL, NULL, NULL, NULL, 'xRayFolder\\data\\180329007\\Image1.png', NULL, NULL, NULL, 'xRayFolder\\data\\180329007\\Report.1.bmp');
INSERT INTO `t_clinicar_check_result` VALUES (820, b'0', '2018-03-29 15:45:22', '180329007', '2378', '泌尿系超', NULL, NULL, NULL, NULL, NULL, 'bc\\data\\180329007\\20180309_101410_0.jpeg', NULL, NULL, NULL, 'bc\\data\\180329007\\Report_Cardiac.html');
INSERT INTO `t_clinicar_check_result` VALUES (821, b'0', '2018-03-29 15:45:23', '180329007', '2390', '电子阴道镜', NULL, NULL, NULL, NULL, NULL, 'ydj\\data\\180329007\\201803272137.pdf', NULL, NULL, NULL, '');

-- ----------------------------
-- Table structure for t_clinicar_consultation
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_consultation`;
CREATE TABLE `t_clinicar_consultation`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `applyhospitalcode` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '申请医院编码',
  `applyhospitalname` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '申请医院名称',
  `applyhospitaltel` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '申请医院电话',
  `applyhospitaldate` datetime(0) DEFAULT NULL COMMENT '申请时间',
  `hospitalcode` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会诊医院编码',
  `hospitalname` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会诊医院名称',
  `deptcode` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '科室编码',
  `deptname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '科室名称',
  `username` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '用户名',
  `consultationdate` date DEFAULT NULL COMMENT '会诊日期',
  `consultationtype` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会诊时间类型（上午、下午）',
  `name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '姓名',
  `check_number` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '检查号',
  `sex` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `age` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `married` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `cardnumber` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `tel` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `diagnosis` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '初步诊断',
  `medicalhistory` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '病史',
  `results` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '会诊结果',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 64 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_consultation
-- ----------------------------
INSERT INTO `t_clinicar_consultation` VALUES (1, '双击选择', '', '', '2018-03-08 17:26:43', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-14', '下午', '生化03', '180308003', '2', NULL, '2', '', '0', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (2, '双击选择', '', '', '2018-03-08 17:35:20', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-15', '下午', '生化03', '180308003', '2', NULL, '2', '', '0', '1', '2', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (3, '双击选择', '', '', '2018-03-08 17:39:45', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-16', '下午', '心电01', '180307008', '2', NULL, '2', '', '0', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (4, '双击选择', '', '', '2018-03-08 17:41:22', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-17', '上午', '福田汽车血液007', '180307007', '2', NULL, '2', '', '0', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (5, '双击选择', '', '', '2018-03-08 17:42:05', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-18', '上午', '福田汽车', '180307002', '2', NULL, '2', '', '0', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (6, '双击选择', '', '', '2018-03-08 17:49:04', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-13', '下午', '福田BC', '180308004', '1', NULL, '3', '213123123123', '1355555555', '213', '23333', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (7, '双击选择', '', '', '2018-03-08 18:48:13', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-17', '下午', '福田BC', '180308004', '1', NULL, '3', '213123123123', '1355555555', '23', '424', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (8, '双击选择', '', '', '2018-03-08 18:52:38', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-18', '下午', '福田BC1', '180308005', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (9, '双击选择', '', '', '2018-03-08 19:04:24', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-16', '上午', '福田BC1', '180308005', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (10, '双击选择', '', '', '2018-03-08 19:40:17', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-12', '下午', '福田BC1', '180308005', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (11, '双击选择', '', '', '2018-03-08 19:54:05', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-15', '上午', '福田BC1', '180308005', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (12, '双击选择', '', '', '2018-03-08 20:06:46', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-14', '上午', '福田BC1', '180308005', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (13, '双击选择', '', '', '2018-03-09 09:43:38', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-13', '上午', '心电01', '180307008', '2', NULL, '2', '', '0', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (14, '双击选择', '', '', '2018-03-09 10:18:09', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-12', '上午', '福田BC2', '180309001', '1', NULL, '3', '213123123123', '1355555555', '2', '3', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (47, '双击选择', '', '', '2018-03-29 11:26:37', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-02', '上午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (48, '双击选择', '', '', '2018-03-29 11:29:37', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-05', '上午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (49, '双击选择', '', '', '2018-03-29 11:49:59', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-06', '上午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (50, '双击选择', '', '', '2018-03-29 12:21:13', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-04', '上午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (51, '双击选择', '', '', '2018-03-29 12:39:11', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-03', '上午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (52, '双击选择', '', '', '2018-03-29 12:40:41', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-07', '上午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (53, '双击选择', '', '', '2018-03-29 12:44:25', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-08', '上午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (54, '双击选择', '', '', '2018-03-29 12:50:03', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-02', '下午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (55, '双击选择', '', '', '2018-03-29 13:01:42', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-03', '下午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (56, '双击选择', '', '', '2018-03-29 13:08:58', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-06', '下午', 'BBBBBBBBBB', '180329002', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (57, '双击选择', '', '', '2018-03-29 13:13:01', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-05', '下午', 'CCCCCCC', '180329003', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (58, '双击选择', '', '', '2018-03-29 13:20:54', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-07', '下午', 'CCCCCCC', '180329003', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (59, '双击选择', '', '', '2018-03-29 13:27:05', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-08', '下午', 'CCCCCCC', '180329003', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (60, '双击选择', '', '', '2018-03-29 13:45:26', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-04-04', '下午', 'DDDDDDDD', '180329004', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (61, '双击选择', '', '', '2018-03-29 14:05:22', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-26', '上午', 'EEEEEEE', '180329005', '1', NULL, '3', '213123123123', '1355555555', 'weqr', '234242', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (62, '双击选择', '', '', '2018-03-29 15:33:02', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-27', '上午', 'FFFFFF', '180329006', '1', NULL, '3', '213123123123', '1355555555', '', '', NULL);
INSERT INTO `t_clinicar_consultation` VALUES (63, '双击选择', '', '', '2018-03-29 15:46:43', 'CS', '流动医院', 'HZS', '会诊室', 'ys', '2018-03-28', '上午', 'GGGGGGG', '180329007', '1', NULL, '3', '213123123123', '1355555555', 'final test', 'dsd', NULL);

-- ----------------------------
-- Table structure for t_clinicar_dpt
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_dpt`;
CREATE TABLE `t_clinicar_dpt`  (
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室编号',
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室名称',
  `enabled` bit(1) DEFAULT NULL COMMENT '是否启用',
  `remark` varchar(400) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '备注',
  `hospitalcode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '医院代码',
  `hospitalname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '医院名称',
  PRIMARY KEY (`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '科室信息表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_dpt
-- ----------------------------
INSERT INTO `t_clinicar_dpt` VALUES ('510', 'B超', b'1', '', 'CS', '流动医院');
INSERT INTO `t_clinicar_dpt` VALUES ('526', '一般检查', b'1', '', 'CS', '流动医院');
INSERT INTO `t_clinicar_dpt` VALUES ('529', 'X光', b'1', '', 'CS', '流动医院');
INSERT INTO `t_clinicar_dpt` VALUES ('540', '心电图', b'1', '', 'CS', '流动医院');
INSERT INTO `t_clinicar_dpt` VALUES ('603', '血细胞分析仪', b'1', '', 'CS', '流动医院');
INSERT INTO `t_clinicar_dpt` VALUES ('604', '生化分析仪', b'1', '', 'CS', '流动医院');
INSERT INTO `t_clinicar_dpt` VALUES ('605', '尿分析仪', b'1', '', 'CS', '流动医院');
INSERT INTO `t_clinicar_dpt` VALUES ('606', '电子阴道镜', b'1', '', 'CS', '流动医院');

-- ----------------------------
-- Table structure for t_clinicar_dpt_sechedul
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_dpt_sechedul`;
CREATE TABLE `t_clinicar_dpt_sechedul`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '排班表编号',
  `sechedulDate` date DEFAULT NULL COMMENT '排班日期',
  `sechedulType` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '排班类型（上午，下午）',
  `deptCode` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '科室编码',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_clinicar_hospital
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_hospital`;
CREATE TABLE `t_clinicar_hospital`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `hospitalcode` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '医院代码',
  `hospitalname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '医院名称',
  `remark` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '备注',
  `tel` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '联系电话',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_hospital
-- ----------------------------
INSERT INTO `t_clinicar_hospital` VALUES (1, 'CS', '流动医院', '2', NULL);

-- ----------------------------
-- Table structure for t_clinicar_item
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_item`;
CREATE TABLE `t_clinicar_item`  (
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查项目编号',
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查项目名称',
  `enabled` bit(1) NOT NULL COMMENT '是否启用',
  `dpt_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室编号',
  `dpt_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室',
  `remark` varchar(400) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '备注',
  `device_code` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '检查设备编号，用于接口对接',
  PRIMARY KEY (`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '检查项基础信息表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_item
-- ----------------------------
INSERT INTO `t_clinicar_item` VALUES ('1589', '外科检查', b'1', '526', '一般检查', '', '');
INSERT INTO `t_clinicar_item` VALUES ('1683', '心电图', b'1', '540', '心电图', '', '02');
INSERT INTO `t_clinicar_item` VALUES ('1797', '妇科检查', b'1', '526', '一般检查', '', '');
INSERT INTO `t_clinicar_item` VALUES ('2050', '颈椎正侧位片', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2053', '腰椎正侧位片', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2059', '口腔检查', b'1', '526', '一般检查', '', '');
INSERT INTO `t_clinicar_item` VALUES ('2067', '内科检查', b'1', '526', '一般检查', '', '');
INSERT INTO `t_clinicar_item` VALUES ('2068', '耳鼻喉检查', b'1', '526', '一般检查', '', '');
INSERT INTO `t_clinicar_item` VALUES ('2069', '眼科检查', b'1', '526', '一般检查', '', '');
INSERT INTO `t_clinicar_item` VALUES ('2115', '胸片正位片', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2116', '胸片正侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2117', '一般情况', b'1', '526', '一般检查', '', '');
INSERT INTO `t_clinicar_item` VALUES ('2240', '颈椎四位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2241', '颈椎六位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2242', '胸椎正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2243', '骶尾侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2244', '骶尾正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2245', '腰椎四位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2246', '盆骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2247', '腹部正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2248', '儿童正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2249', '儿童正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2250', '髋关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2251', '髋关节正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2252', '股骨正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2253', '左胫腓骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2254', '右胫腓骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2255', '左膝关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2256', '右膝关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2257', '左踝关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2258', '右踝关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2259', '左足正斜', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2260', '右足正斜', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2261', '左手正斜', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2262', '右手正斜', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2263', '左跟骨侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2264', '右跟骨侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2265', '左跟骨侧轴位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2266', '右跟骨侧轴位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2267', '左锁骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2268', '右锁骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2269', '左肩关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2270', '右肩关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2271', '左肩关节正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2272', '右肩关节正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2273', '左肱骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2274', '右肱骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2275', '左肘关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2276', '右肘关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2277', '左尺桡骨正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2278', '右尺桡骨正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2279', '左腕关节正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2280', '右腕关节正侧', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2295', '上消化道钡餐检查', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2342', '左膝关节正侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2343', '右膝关节正侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2346', '双侧胫腓骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2347', '双侧膝关节正侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2348', '双侧踝关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2349', '双侧足关节正斜位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2350', '双侧手关节正斜位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2351', '双侧跟骨侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2352', '双侧锁骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2353', '双侧肩关节正侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2354', '双侧肱骨正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2355', '双侧肘关节正位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2356', '双侧尺桡骨正侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2357', '双侧腕关节正侧位', b'1', '529', 'X光', '', '01');
INSERT INTO `t_clinicar_item` VALUES ('2374', '腹部彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2375', '腹部大血管彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2376', '下肢血管彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2377', '阴道彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2378', '泌尿系超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2379', '妇科彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2380', '乳腺彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2381', '前列腺彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2382', '精囊彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2383', '心脏彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2384', '颈动脉彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2385', '甲状腺彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2387', '浅表淋巴结彩超', b'1', '510', 'B超', '', '03');
INSERT INTO `t_clinicar_item` VALUES ('2388', '尿常规', b'1', '605', '尿分析仪', '', '05');
INSERT INTO `t_clinicar_item` VALUES ('2389', '生化全项', b'1', '604', '生化分析仪', '', '07');
INSERT INTO `t_clinicar_item` VALUES ('2390', '电子阴道镜', b'1', '606', '电子阴道镜', '', '04');
INSERT INTO `t_clinicar_item` VALUES ('2391', '血常规', b'1', '603', '血细胞分析仪', '', '06');

-- ----------------------------
-- Table structure for t_clinicar_item_detail
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_item_detail`;
CREATE TABLE `t_clinicar_item_detail`  (
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '具体检查项目代码',
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '具体检查项目名称',
  `item_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查项目代码',
  `unit` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '单位',
  PRIMARY KEY (`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '检查项明细项目基础信息表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinicar_item_detail
-- ----------------------------
INSERT INTO `t_clinicar_item_detail` VALUES ('10114', '身高', '2117', 'cm');
INSERT INTO `t_clinicar_item_detail` VALUES ('10115', '体重', '2117', 'Kg');
INSERT INTO `t_clinicar_item_detail` VALUES ('10116', '体重指数', '2117', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10117', '血压(收缩压)', '2117', 'mmHg');
INSERT INTO `t_clinicar_item_detail` VALUES ('10118', '血压(舒张压)', '2117', 'mmHg');
INSERT INTO `t_clinicar_item_detail` VALUES ('10119', '心率', '2117', 'bpm');
INSERT INTO `t_clinicar_item_detail` VALUES ('10130', '肺部', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10131', '腹部触诊', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10132', '杂音', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10133', '心率', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10134', '节律', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10135', '肝', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10136', '精神及神经', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10137', '脾脏', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10138', '其他', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10139', '询问病史', '2067', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10140', '皮肤', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10141', '四肢', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10142', '脊柱', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10143', '浅表淋巴结', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10144', '肛肠', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10145', '甲状腺', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10146', '泌尿生殖器', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10147', '乳房', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10148', '其他', '1589', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10149', '视力(左)', '2069', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10150', '视力(右)', '2069', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10151', '辨色力', '2069', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10152', '外眼', '2069', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10153', '色觉', '2069', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10222', '白细胞', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10223', '亚硝酸盐', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10224', '尿胆原', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10225', '蛋白', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10226', 'PH', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10227', '潜血', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10228', '比重', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10229', '酮体', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10230', '胆红素', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10231', '葡萄糖', '2388', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10232', '维生素C', '2388', 'uh');
INSERT INTO `t_clinicar_item_detail` VALUES ('10233', '丙氨酸氨基转移酶', '2389', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10234', '天门冬氨酸氨基转移酶', '2389', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10235', '碱性磷酸酶', '2389', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10236', 'γ-谷胺酰转肽酶', '2389', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10237', '肌酸激酶', '2389', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10259', '白细胞数', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10260', '中性粒细胞百分比', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10261', '淋巴细胞数目', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10262', '红细胞数目', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10263', '血红蛋白', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10264', '红细胞压积', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10265', '平均红细胞体积', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10266', '平均红细胞血红蛋白含量', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10267', '平均红细胞血红蛋白浓度', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10268', '红细胞分布宽度变异系数', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10269', '血小板数目', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10270', '平均血小板体积', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10271', '血小板压积', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10272', '血小板分布宽度', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10273', '细胞分布宽度标准差', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('10274', '中间细胞数目', '2391', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8565', '齿', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8566', '唇', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8567', '颊', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8568', '齿龈', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8569', '牙周', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8570', '舌', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8571', '腭', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8572', '腮腺', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8573', '颌下腺', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('8574', '颞下颌关节', '2059', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9968', '听力(左)', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9969', '听力(右)', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9970', '外耳道', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9971', '鼓膜', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9972', '鼻前庭', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9973', '鼻甲', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9974', '鼻咽', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9975', '咽部', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9976', '鼻道', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('9977', '喉部', '2068', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('bultra', 'B超', '003', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('colposcope', '阴道镜', '004', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('heart', '心电图', '002', '');
INSERT INTO `t_clinicar_item_detail` VALUES ('xray', 'X光', '001', '');

-- ----------------------------
-- Table structure for t_clinicar_patient
-- ----------------------------
DROP TABLE IF EXISTS `t_clinicar_patient`;
CREATE TABLE `t_clinicar_patient`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '代理主键',
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '姓名',
  `gender_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '性别编码',
  `gender_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '性别',
  `nationality_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '民族编号',
  `nationality_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '民族',
  `birthday` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '出生日期',
  `marital_status_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '婚姻状况编码',
  `marital_status_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '婚姻状况',
  `certificate_type_code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '证件类型编码',
  `certificate_type_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '证件类型',
  `certificate_number` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '证件号',
  `address` varchar(400) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '地址',
  `tel` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '联系电话',
  `remark` varchar(400) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '患者信息表' ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_clinihospital_dpt
-- ----------------------------
DROP TABLE IF EXISTS `t_clinihospital_dpt`;
CREATE TABLE `t_clinihospital_dpt`  (
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室编号',
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室名称',
  `enabled` bit(1) DEFAULT NULL COMMENT '是否启用',
  `remark` varchar(400) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '备注',
  `hospitalcode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '医院代码',
  `hospitalname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '医院名称',
  PRIMARY KEY (`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '科室信息表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_clinihospital_dpt
-- ----------------------------
INSERT INTO `t_clinihospital_dpt` VALUES ('HZS', '会诊室', b'1', '会诊室', 'HZ', '会诊医院');

-- ----------------------------
-- Table structure for t_interface_data
-- ----------------------------
DROP TABLE IF EXISTS `t_interface_data`;
CREATE TABLE `t_interface_data`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '代理主键',
  `deleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '删除标记',
  `code` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '检查号',
  `device_code` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '设备号',
  `receipt_time` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '接收时间',
  `data` varchar(5000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '接收的数据',
  `attachment_names` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '附件名称（多个英文逗号隔开）',
  `attachment_paths` varchar(5000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '附件地址（多个英文逗号隔开）',
  `analyzed` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否已经解析',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 244 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '采集端上传数据' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_interface_data
-- ----------------------------
INSERT INTO `t_interface_data` VALUES (233, b'0', '001', '605', '2018-03-07 13:25:22', '2018-03-07\r\n13:24:04\r\n001\r\n\r\n LEU	-          \r\n NIT	-          \r\n URO	norm.      \r\n PRO	-          \r\n PH 	6.5        \r\n BLD	-          \r\n SG 	1.005      \r\n KET	-          \r\n BIL	1+         \r\n GLU	-          \r\n ASC	3+         \r\n', NULL, NULL, b'1');
INSERT INTO `t_interface_data` VALUES (234, b'0', '002', '605', '2018-03-07 13:31:37', '2018-03-07\r\n13:30:22\r\n002\r\n\r\n LEU	-          \r\n NIT	-          \r\n URO	norm.      \r\n PRO	-          \r\n PH 	6.5        \r\n BLD	-          \r\n SG 	1.005      \r\n KET	-          \r\n BIL	1+         \r\n GLU	-          \r\n ASC	3+         \r\n', NULL, NULL, b'1');
INSERT INTO `t_interface_data` VALUES (235, b'0', '180307003', '603', '2018-03-07 17:29:41', 'MSH|^~\\&|||||20180307172730||ORU^R01|1|P|2.3.1||||||UNICODE\rPID|1||^^^^MR\rPV1|1\rOBR|1||180307003|00001^Automated Count^99MRC|||20180307171804|||||||||||||||||HM||||||||service\rOBX|1|IS|08001^Take Mode^99MRC||O||||||F\rOBX|2|IS|08002^Blood Mode^99MRC||W||||||F\rOBX|3|IS|01002^Ref Group^99MRC||通用||||||F\rOBX|4|IS|6690-2^WBC^LN||0.0|10*9/L|4.0-10.0|L~N|||F\rOBX|5|IS|731-0^LYM#^LN||*****|10*9/L|0.8-4.0|N|||F\rOBX|6|IS|736-9^LYM%^LN||*****|%|20.0-40.0|N|||F\rOBX|7|IS|789-8^RBC^LN||0.00|10*12/L|3.50-5.50|L~N|||F\rOBX|8|IS|718-7^HGB^LN||0|g/L|110-160|L~N|||F\rOBX|9|IS|787-2^MCV^LN||*****|fL|80.0-100.0|N|||F\rOBX|10|IS|785-6^MCH^LN||*****|pg|27.0-34.0|N|||F\rOBX|11|IS|786-4^MCHC^LN||*****|g/L|320-360|N|||F\rOBX|12|IS|788-0^RDW-CV^LN||*****|%|11.0-16.0|N|||F\rOBX|13|IS|21000-5^RDW-SD^LN||*****|fL|35.0-56.0|N|||F\rOBX|14|IS|4544-3^HCT^LN||0.0|%|37.0-54.0|L~N|||F\rOBX|15|IS|777-3^PLT^LN||1|10*9/L|100-300|L~N|||F\rOBX|16|IS|32623-1^MPV^LN||*****|fL|6.5-12.0|N|||F\rOBX|17|IS|32207-3^PDW^LN||*****||15.0-17.0|N|||F\rOBX|18|IS|10002^PCT^99MRC||*****|%|0.108-0.282|N|||F\rOBX|19|IS|10027^MID#^99MRC||*****|10*9/L|0.1-1.5|N|||F\rOBX|20|IS|10029^MID%^99MRC||*****|%|3.0-15.0|N|||F\rOBX|21|IS|10028^GRAN#^99MRC||*****|10*9/L|2.0-7.0|N|||F\rOBX|22|IS|10030^GRAN%^99MRC||*****|%|50.0-70.0|N|||F\r', NULL, NULL, b'1');
INSERT INTO `t_interface_data` VALUES (236, b'0', '180307004', '603', '2018-03-07 17:35:26', 'MSH|^~\\&|||||20180307173313||ORU^R01|2|P|2.3.1||||||UNICODE\rPID|1||^^^^MR\rPV1|1\rOBR|1||180307004|00001^Automated Count^99MRC|||20180307173201|||||||||||||||||HM||||||||service\rOBX|1|IS|08001^Take Mode^99MRC||O||||||F\rOBX|2|IS|08002^Blood Mode^99MRC||W||||||F\rOBX|3|IS|01002^Ref Group^99MRC||通用||||||F\rOBX|4|IS|6690-2^WBC^LN||0.0|10*9/L|4.0-10.0|L~N|||F\rOBX|5|IS|731-0^LYM#^LN||*****|10*9/L|0.8-4.0|N|||F\rOBX|6|IS|736-9^LYM%^LN||*****|%|20.0-40.0|N|||F\rOBX|7|IS|789-8^RBC^LN||0.00|10*12/L|3.50-5.50|L~N|||F\rOBX|8|IS|718-7^HGB^LN||1|g/L|110-160|L~N|||F\rOBX|9|IS|787-2^MCV^LN||*****|fL|80.0-100.0|N|||F\rOBX|10|IS|785-6^MCH^LN||*****|pg|27.0-34.0|N|||F\rOBX|11|IS|786-4^MCHC^LN||*****|g/L|320-360|N|||F\rOBX|12|IS|788-0^RDW-CV^LN||*****|%|11.0-16.0|N|||F\rOBX|13|IS|21000-5^RDW-SD^LN||*****|fL|35.0-56.0|N|||F\rOBX|14|IS|4544-3^HCT^LN||0.0|%|37.0-54.0|L~N|||F\rOBX|15|IS|777-3^PLT^LN||1|10*9/L|100-300|L~N|||F\rOBX|16|IS|32623-1^MPV^LN||*****|fL|6.5-12.0|N|||F\rOBX|17|IS|32207-3^PDW^LN||*****||15.0-17.0|N|||F\rOBX|18|IS|10002^PCT^99MRC||*****|%|0.108-0.282|N|||F\rOBX|19|IS|10027^MID#^99MRC||*****|10*9/L|0.1-1.5|N|||F\rOBX|20|IS|10029^MID%^99MRC||*****|%|3.0-15.0|N|||F\rOBX|21|IS|10028^GRAN#^99MRC||*****|10*9/L|2.0-7.0|N|||F\rOBX|22|IS|10030^GRAN%^99MRC||*****|%|50.0-70.0|N|||F\r', NULL, NULL, b'0');
INSERT INTO `t_interface_data` VALUES (237, b'0', '180307005', '603', '2018-03-07 17:38:26', 'MSH|^~\\&|||||20180307173614||ORU^R01|3|P|2.3.1||||||UNICODE\rPID|1||^^^^MR\rPV1|1\rOBR|1||180307005|00001^Automated Count^99MRC|||20180307173502|||||||||||||||||HM||||||||service\rOBX|1|IS|08001^Take Mode^99MRC||O||||||F\rOBX|2|IS|08002^Blood Mode^99MRC||W||||||F\rOBX|3|IS|01002^Ref Group^99MRC||通用||||||F\rOBX|4|IS|6690-2^WBC^LN||0.0|10*9/L|4.0-10.0|L~N|||F\rOBX|5|IS|731-0^LYM#^LN||*****|10*9/L|0.8-4.0|N|||F\rOBX|6|IS|736-9^LYM%^LN||*****|%|20.0-40.0|N|||F\rOBX|7|IS|789-8^RBC^LN||0.00|10*12/L|3.50-5.50|L~N|||F\rOBX|8|IS|718-7^HGB^LN||1|g/L|110-160|L~N|||F\rOBX|9|IS|787-2^MCV^LN||*****|fL|80.0-100.0|N|||F\rOBX|10|IS|785-6^MCH^LN||*****|pg|27.0-34.0|N|||F\rOBX|11|IS|786-4^MCHC^LN||*****|g/L|320-360|N|||F\rOBX|12|IS|788-0^RDW-CV^LN||*****|%|11.0-16.0|N|||F\rOBX|13|IS|21000-5^RDW-SD^LN||*****|fL|35.0-56.0|N|||F\rOBX|14|IS|4544-3^HCT^LN||0.0|%|37.0-54.0|L~N|||F\rOBX|15|IS|777-3^PLT^LN||1|10*9/L|100-300|L~N|||F\rOBX|16|IS|32623-1^MPV^LN||*****|fL|6.5-12.0|N|||F\rOBX|17|IS|32207-3^PDW^LN||*****||15.0-17.0|N|||F\rOBX|18|IS|10002^PCT^99MRC||*****|%|0.108-0.282|N|||F\rOBX|19|IS|10027^MID#^99MRC||*****|10*9/L|0.1-1.5|N|||F\rOBX|20|IS|10029^MID%^99MRC||*****|%|3.0-15.0|N|||F\rOBX|21|IS|10028^GRAN#^99MRC||*****|10*9/L|2.0-7.0|N|||F\rOBX|22|IS|10030^GRAN%^99MRC||*****|%|50.0-70.0|N|||F\r', NULL, NULL, b'1');
INSERT INTO `t_interface_data` VALUES (238, b'0', '180307007', '603', '2018-03-07 18:57:19', 'MSH|^~\\&|||||20180307185507||ORU^R01|1|P|2.3.1||||||UNICODE\rPID|1||^^^^MR\rPV1|1\rOBR|1||180307007|00001^Automated Count^99MRC|||20180307185355|||||||||||||||||HM||||||||Administrator\rOBX|1|IS|08001^Take Mode^99MRC||O||||||F\rOBX|2|IS|08002^Blood Mode^99MRC||W||||||F\rOBX|3|IS|01002^Ref Group^99MRC||通用||||||F\rOBX|4|IS|6690-2^WBC^LN||0.0|10*9/L|4.0-10.0|L~N|||F\rOBX|5|IS|731-0^LYM#^LN||*****|10*9/L|0.8-4.0|N|||F\rOBX|6|IS|736-9^LYM%^LN||*****|%|20.0-40.0|N|||F\rOBX|7|IS|789-8^RBC^LN||0.00|10*12/L|3.50-5.50|L~N|||F\rOBX|8|IS|718-7^HGB^LN||1|g/L|110-160|L~N|||F\rOBX|9|IS|787-2^MCV^LN||*****|fL|80.0-100.0|N|||F\rOBX|10|IS|785-6^MCH^LN||*****|pg|27.0-34.0|N|||F\rOBX|11|IS|786-4^MCHC^LN||*****|g/L|320-360|N|||F\rOBX|12|IS|788-0^RDW-CV^LN||*****|%|11.0-16.0|N|||F\rOBX|13|IS|21000-5^RDW-SD^LN||*****|fL|35.0-56.0|N|||F\rOBX|14|IS|4544-3^HCT^LN||0.0|%|37.0-54.0|L~N|||F\rOBX|15|IS|777-3^PLT^LN||2|10*9/L|100-300|L~N|||F\rOBX|16|IS|32623-1^MPV^LN||*****|fL|6.5-12.0|N|||F\rOBX|17|IS|32207-3^PDW^LN||*****||15.0-17.0|N|||F\rOBX|18|IS|10002^PCT^99MRC||*****|%|0.108-0.282|N|||F\rOBX|19|IS|10027^MID#^99MRC||*****|10*9/L|0.1-1.5|N|||F\rOBX|20|IS|10029^MID%^99MRC||*****|%|3.0-15.0|N|||F\rOBX|21|IS|10028^GRAN#^99MRC||*****|10*9/L|2.0-7.0|N|||F\rOBX|22|IS|10030^GRAN%^99MRC||*****|%|50.0-70.0|N|||F\r', NULL, NULL, b'1');
INSERT INTO `t_interface_data` VALUES (239, b'0', '180307006', '603', '2018-03-07 18:58:34', 'MSH|^~\\&|||||20180307185623||ORU^R01|2|P|2.3.1||||||UNICODE\rPID|1||^^^^MR\rPV1|1\rOBR|1||180307006|00001^Automated Count^99MRC|||20180307185129|||||||||||||||||HM||||||||Administrator\rOBX|1|IS|08001^Take Mode^99MRC||O||||||F\rOBX|2|IS|08002^Blood Mode^99MRC||W||||||F\rOBX|3|IS|01002^Ref Group^99MRC||通用||||||F\rOBX|4|IS|6690-2^WBC^LN||0.0|10*9/L|4.0-10.0|L~N|||F\rOBX|5|IS|731-0^LYM#^LN||*****|10*9/L|0.8-4.0|N|||F\rOBX|6|IS|736-9^LYM%^LN||*****|%|20.0-40.0|N|||F\rOBX|7|IS|789-8^RBC^LN||0.00|10*12/L|3.50-5.50|L~N|||F\rOBX|8|IS|718-7^HGB^LN||1|g/L|110-160|L~N|||F\rOBX|9|IS|787-2^MCV^LN||*****|fL|80.0-100.0|N|||F\rOBX|10|IS|785-6^MCH^LN||*****|pg|27.0-34.0|N|||F\rOBX|11|IS|786-4^MCHC^LN||*****|g/L|320-360|N|||F\rOBX|12|IS|788-0^RDW-CV^LN||*****|%|11.0-16.0|N|||F\rOBX|13|IS|21000-5^RDW-SD^LN||*****|fL|35.0-56.0|N|||F\rOBX|14|IS|4544-3^HCT^LN||0.0|%|37.0-54.0|L~N|||F\rOBX|15|IS|777-3^PLT^LN||2|10*9/L|100-300|L~N|||F\rOBX|16|IS|32623-1^MPV^LN||*****|fL|6.5-12.0|N|||F\rOBX|17|IS|32207-3^PDW^LN||*****||15.0-17.0|N|||F\rOBX|18|IS|10002^PCT^99MRC||*****|%|0.108-0.282|N|||F\rOBX|19|IS|10027^MID#^99MRC||*****|10*9/L|0.1-1.5|N|||F\rOBX|20|IS|10029^MID%^99MRC||*****|%|3.0-15.0|N|||F\rOBX|21|IS|10028^GRAN#^99MRC||*****|10*9/L|2.0-7.0|N|||F\rOBX|22|IS|10030^GRAN%^99MRC||*****|%|50.0-70.0|N|||F\r', NULL, NULL, b'1');
INSERT INTO `t_interface_data` VALUES (240, b'0', '201803072', '540', '2018-03-07 20:31:10', NULL, 'heart_20180307203109_0.zip', '/heartFolder/src/20180307/20180307203110_790.zip', b'0');
INSERT INTO `t_interface_data` VALUES (241, b'0', '180307008', '540', '2018-03-07 20:32:44', NULL, 'heart_20180307203244_0.zip', '/heartFolder/src/20180307/20180307203244_478.zip', b'1');
INSERT INTO `t_interface_data` VALUES (242, b'0', '1803080021', '604', '2018-03-08 14:17:29', 'MSH|^~\\&|||||20180308141745||ORU^R01|1|P|2.3.1||||0||ASCII\rPID|4|1803080022||||||M\rOBR|4|1803080021|180308002||N|20180308140435|20180308140347|20180308140347||1^2||||20180308140347|Serum\rOBX|1|NM|||-0.000397|mmol/L|-|N|||F||-0.000397|20180308141358|||0\r', NULL, NULL, b'0');
INSERT INTO `t_interface_data` VALUES (243, b'0', '180308003', '604', '2018-03-08 14:43:21', 'MSH|^~\\&|||||20180308144337||ORU^R01|2|P|2.3.1||||0||ASCII\rPID|5|||||||O\rOBR|5|180308003|180308003||N|20180308143129|20180308143057|20180308143057||1^3||||20180308143057|Serum\rOBX|1|NM||ALT1|-0.000397|mmol/L|-|N|||F||-0.000397|20180308144110|||0\rOBX|2|NM||AST1|0.000117|mmol/L|-|N|||F||0.000117|20180308144120|||0\r', NULL, NULL, b'1');

-- ----------------------------
-- Table structure for t_sys_dict
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_dict`;
CREATE TABLE `t_sys_dict`  (
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '编码',
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '名称',
  `pcode` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '上级编码',
  `sort` varchar(3) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '数据分类',
  `enabled` bit(1) NOT NULL COMMENT '是否启用（0否，1是）',
  `display_order` int(11) NOT NULL COMMENT '显示顺序',
  `remark` varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '基础数据表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_sys_dict
-- ----------------------------
INSERT INTO `t_sys_dict` VALUES ('测试', 'AA', '', '01', b'1', 1, '吃');

-- ----------------------------
-- Table structure for t_sys_user
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_user`;
CREATE TABLE `t_sys_user`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '代理主键',
  `username` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户名',
  `password` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '密码',
  `user_type` varchar(2) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户类型（01=超管；11=系统管理员；21=医生）',
  `full_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '姓名',
  `tel` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '电话',
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '系统用户表' ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_sys_user
-- ----------------------------
INSERT INTO `t_sys_user` VALUES (1, 'admin', 'admin', '11', '11', '11', '111');
INSERT INTO `t_sys_user` VALUES (3, 'ys', 'ys', '21', 'sad', '13', '1');

SET FOREIGN_KEY_CHECKS = 1;
