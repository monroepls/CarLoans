


update [User]
set Password = convert(varchar(64),
hashbytes('MD5', Password), 2)

update [User]
set Login = convert(varchar(64),
hashbytes('MD5', Login), 2)

select * from [User]

