---
title: ExtString
author: 骆宏伟
date: 2021-07-26
category: DataType
layout: post
---

## Method

#### IsNullOrEmpty
check the string value is null or empty
```
string s=string.Empty;
Console.WriteLine(s.IsNullOrEmpty());
s=null;
Console.WriteLine(s.IsNullOrEmpty());
s="";
Console.WriteLine(s.IsNullOrEmpty());
```
output:
```
True
True
True
```

#### GetInt
convert string to int
```
string s=string.Empty;
Console.WriteLine(s.GetInt());
s=null;
Console.WriteLine(s.GetInt());
s="";
Console.WriteLine(s.GetInt());
s="abc";
Console.WriteLine(s.GetInt());
s="12";
Console.WriteLine(s.GetInt());
```
output:
```
0
0
0
0
12
```

#### GetLong
convert string to long
```
string s="111111111111111";
Console.WriteLine(s.GetLong());
```
output:
```
111111111111111
```

#### GetBool
convert string to bool,if string is null or string empty or false,return false,else return true
```
string s=null;
Console.WriteLine(s.GetBool());
s="";
Console.WriteLine(s.GetBool());
s="0";
Console.WriteLine(s.GetBool());
s="false";
Console.WriteLine(s.GetBool());
s="1";
Console.WriteLine(s.GetBool());
s="true";
Console.WriteLine(s.GetBool());
```
output:
```
False
False
False
False
True
True
```

#### GetDecimal
convert string to decimal
```
string s="";
Console.WriteLine(s.GetDecimal());
s="1.233425452";
Console.WriteLine(s.GetDecimal());
s="false";
Console.WriteLine(s.GetDecimal());
```
output:
```
0
1.233425452
0
```

#### GetDouble
convert string to double
```
string s="";
Console.WriteLine(s.GetDouble());
s="1.233425452";
Console.WriteLine(s.GetDouble());
s="false";
Console.WriteLine(s.GetDouble());
```
output:
```
0
1.233425452
0
```

#### GetFloat
convert string to float
```
string s="";
Console.WriteLine(s.GetFloat());
s="1.233425452";
Console.WriteLine(s.GetFloat());
s="false";
Console.WriteLine(s.GetFloat());
```
output:
```
0
1.233425452
0
```

#### GetDateTime
convert string to datetime,if string is not time format,return current time
```
string s=null;
Console.WriteLine(s.GetDateTime());
s="";
Console.WriteLine(s.GetDateTime());
s="2021-07-27 12:12:12";
Console.WriteLine(s.GetDateTime());
```
output:
```
2021/7/27 1:40:06
2021/7/27 1:40:06
2021/7/27 12:12:12
```

#### Subs
substring.If string is null or empty return empty.If param length is big than string's length,return string else substring of length string with suffix.
```
string s="abcdefghijkmnopqrstuvwxyz";
Console.WriteLine(s.Subs(27));
Console.WriteLine(s.Subs(3));
Console.WriteLine(s.Subs(3,"..."));
Console.WriteLine(s.Subs(1,3));
s=null;
Console.WriteLine(s.Subs(3,"..."));
```
output:
```
abcdefghijkmnopqrstuvwxyz
abc
abc...
bcd

```

#### ToBase64
convert string to base64
```
string s="abcdefg";
Console.WriteLine(s.ToBase64());
```
output:
```
YWJjZGVmZw==
```

#### FromBase64
convert to string from base64
```
string s="YWJjZGVmZw==";
Console.WriteLine(s.FromBase64());
```
output:
```
abcdefg
```

#### Left
Get count of chars start left.If param count is bigger than length of string ,return string direct.
```
string s="0123456789";
s.Left(3)
```
output:
```
012
```

#### Right
Get count of chars start right.If param count is bigger than length of string ,return string direct.
```
string s="0123456789";
s.Right(3)
```
output:
```
789
```