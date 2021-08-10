---
title: ExtDataTable
author: 骆宏伟
date: 2021-07-30
category: DataType
layout: post
---

## Method

#### ReplaceDbNull
replace dbnull

#### OrderBy
sort the datatable order by param sort.i.e:i.e:id desc

#### Where
filter the data

#### Rows00
return the first column of first row data.If has not data,return null.

#### Rows00Int
return the first column of first row data,and convert to int.If has not data,return 0.

#### RowsMN(int indexOfRow, int indexOfColumn)
return the N'th column of M'th row data.If has not data,return null.

#### RowsMN(int indexOfRow, string columnName)
return the speical name of column of M'th row data.If has not data,return null. 

#### Skip
return the data,skip the num rows.If row count is less than num,return empty table.

#### Take
Take the num rows of datatable.

