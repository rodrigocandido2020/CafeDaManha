USE [CafeDaManhaContext-1aaf44b7-1484-41aa-ae45-d337a85ae247] 
GO  
ALTER TABLE CadastroCafe  
ADD CONSTRAINT AK_Alimento UNIQUE (Alimento);   
GO  