# ConfigurationReader_BeymenCase

Davranışsal tasarım desenlerinden olan MediatorPattern ile geliştirilmiş case projesidir. 

### Database olarak Mssql kullanılmış olup aşağıdaki tablonun  create edilmesi gerekmektedir. 

```sql
CREATE TABLE [dbo].[Configuration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Value] [nvarchar](50) NULL,
	[IsActive] [tinyint] NULL,
	[ApplicationName] [nvarchar](50) NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
```


### Tablo create edildikten sonra aşaıdaki veriler insert edilmelidir. 

```sql
USE [BeymenCodeCaseDB]
GO
INSERT INTO [dbo].[Configuration]
           ([Name]
           ,[Type]
           ,[Value]
           ,[IsActive]
           ,[ApplicationName])
VALUES('integer-name'
       ,'Integer'
       ,2
       ,1
       ,'test-app'),
       ('string-name'
       ,'Integer'
       ,22
       ,1
       ,'test-app'),
       ('boolean-name'
       ,'Boolean'
       ,1
       ,1
       ,'test-app')
GO

```
### UI projesinde connection string  appsettings.json dosyasına aşağıdaki gibi eklenmelidir. 
"ConnectionStrings":{
"BeymenDb": "{{CONNECTION_STRING}}"
}







