CREATE TABLE `CommandLines` (
  `Id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `ApplicationName` varchar(100) CHARACTER SET ascii COLLATE ascii_bin NOT NULL DEFAULT 'bash' COMMENT 'Ứng dụng chạy lệnh',
  `Content` varchar(2048) COLLATE utf8_unicode_ci NOT NULL DEFAULT '' COMMENT 'Nội dung câu lệnh',
  `Description` varchar(500) COLLATE utf8_unicode_ci NOT NULL DEFAULT '' COMMENT 'Mô tả câu lệnh',
  `CreatedOn` date NOT NULL COMMENT 'Ngày tạo',
  `ModifiedOn` datetime NOT NULL COMMENT 'Ngày cập nhật cuối cùng',
  `Status` tinyint(3) unsigned NOT NULL DEFAULT 0 COMMENT 'Trạng thái của CLI',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='Câu lệnh CLI'