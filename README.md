# ChineseHyphenation_Unity
教學網站:

1. https://gsp40213.pixnet.net/blog/post/231486448-(simple)-chinese-hyphenation-for-unity---%E6%96%B7%E8%A9%9E
2. https://unityblenderskillbook.blogspot.com/2021/12/simple-chinese-hyphenation-for-unity.html

-----------------------------------------
使用方式:

        ※ Assets/Projectpackage/ChineseHyphenation.rar (裡面有2019-LTS 版本與2020.1版本)

1. 需建立資料庫 (Mysql)，再到 Relevant information/MySql/corpus2.sql 檔案匯入資料庫。

2. EnterOnClick 腳本需修改資料庫連接參數: IP、database、password、port

        new MySQLFunction(hort, id, passward, database, port); 
             
-----------------------------------------
注意事項: 

1. 資料庫裡面沒有的詞語會顯示(?)
2. 搜尋的句子太長，需要等待較久的時間，才會顯示斷詞後結果。
3. 長詞優先演算法，需龐大詞語，目前語料庫詞彙數量，偏向常用文章。

-----------------------------------------
![image](https://github.com/gsp40213/ChineseHyphenation_Unity2020/blob/main/Assets/Textrue2D/Result_Image/ResultImage.png)
