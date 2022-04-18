-- ALTER DATABASE Test SET trustworthy ON
-- EXEC sp_configure 'clr enabled';  
-- EXEC sp_configure 'clr enabled' , '1';  
-- RECONFIGURE;    


-- Tạo mới khách hàng
use Test;
DROP PROCEDURE IF EXISTS StoreCustomer
DROP ASSEMBLY IF EXISTS EplusKiotViet
go

CREATE ASSEMBLY EplusKiotViet from 'D:\C#\EplusKiotViet\EplusKiotViet\bin\Debug\EplusKiotViet.dll' WITH PERMISSION_SET = UNSAFE;

go


CREATE PROCEDURE StoreCustomer(@code nchar(48),@name nchar(500),@tel nvarchar(50),@address nvarchar(500), @out nchar(2000) OUTPUT)
AS  
EXTERNAL NAME EplusKiotViet.CLR.CreateCustomer;
Go


DECLARE @name nvarchar(500) 
DECLARE @code nvarchar(48) 
DECLARE @tel nvarchar(24) 
DECLARE @adress nvarchar(500) 
DECLARE @OUT nvarchar(1000)  

SET @code = N'KH06072021'
SET @name =N'thangvm'
SET @tel =N'0999999999'
SET @adress =N'thangvm'

EXEC StoreCustomer @code,@nane,@tel,@adress,@OUT out
PRINT @OUT





--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#

-- Tạo mới sản phẩm
use Test;
DROP PROCEDURE IF EXISTS StoreSku
--DROP ASSEMBLY IF EXISTS EplusKiotViet -- Cái này chạy ở trên khách hàng rồi thì bỏ đi không chạy lại cái này nữa
go

--CREATE ASSEMBLY EplusKiotViet from 'D:\C#\EplusKiotViet\EplusKiotViet\bin\Debug\EplusKiotViet.dll' WITH PERMISSION_SET = UNSAFE; -- Cái này chạy ở trên khách hàng rồi thì bỏ đi không chạy lại cái này nữa

--go


CREATE PROCEDURE StoreSku(@code nchar(48),@name nchar(500),@unit nvarchar(24), @out nchar(2000) OUTPUT)
AS  
EXTERNAL NAME EplusKiotViet.CLR.CreateSku;
Go



DECLARE @OUT nvarchar(1000)  
DECLARE @name nvarchar(500) 
DECLARE @code nvarchar(48) 
DECLARE @unit nvarchar(24) 

SET @code = N'KH060720211'
SET @name =N'thangvm1'
SET @unit =N'cái'

EXEC StoreSku @code,@name,@unit,@OUT out
PRINT @OUT




--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#
--#

-- Đẩy tồn(có thể đẩy 1 hoặc nhiều mã 1 lúc)
use Test;
DROP PROCEDURE IF EXISTS UpdateInventory
--DROP ASSEMBLY IF EXISTS EplusKiotViet -- Cái này chạy ở trên khách hàng rồi thì bỏ đi không chạy lại cái này nữa
go

--CREATE ASSEMBLY EplusKiotViet from 'D:\C#\EplusKiotViet\EplusKiotViet\bin\Debug\EplusKiotViet.dll' WITH PERMISSION_SET = UNSAFE; -- Cái này chạy ở trên khách hàng rồi thì bỏ đi không chạy lại cái này nữa

--go

-- đẩy tối đa 50 mã 1 lúc có thể tối đa 100 mã
CREATE PROCEDURE UpdateInventory(@code nchar(2000),@unit nchar(2000), @out nchar(2000) OUTPUT)
AS  
EXTERNAL NAME EplusKiotViet.CLR.UpdateInventory;
Go



DECLARE @OUT nvarchar(1000)  
DECLARE @code nvarchar(48) 
DECLARE @amount nvarchar(24) 

-- các mã cách nhau bởi dấu ","
SET @code = N'thangvm1,thangvm'
-- các số lượng của mã cách nhau bởi dấu ","
SET @amount =N'100,100'

EXEC UpdateInventory @code,@amount,@OUT out
PRINT @OUT


