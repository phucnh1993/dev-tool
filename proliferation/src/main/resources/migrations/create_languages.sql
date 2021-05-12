CREATE TABLE `Languages` (
  `Id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET ascii NOT NULL,
  `Version` varchar(20) CHARACTER SET ascii COLLATE ascii_bin NOT NULL DEFAULT '1',
  `Description` varchar(500) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `CreatedOn` date NOT NULL,
  `ModifiedOn` datetime NOT NULL,
  `Status` tinyint(3) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='Ngôn ngữ code'