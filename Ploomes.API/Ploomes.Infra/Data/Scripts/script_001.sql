If Not Exists (Select * From SysObjects Where XTYPE = 'U' And NAME = 'Client') 
Begin
  Create Table Client(
         IdClient   UniqueIdentifier,
         NameClient Varchar(150),
         Updated    DateTime
  )
End
go