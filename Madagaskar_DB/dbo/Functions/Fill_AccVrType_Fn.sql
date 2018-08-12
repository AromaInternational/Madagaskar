
-- Author       :PRADEEP.T.V
-- Created Date :25/06/2016
-- SELECT * FROM  dbo.Fill_AccVrType_Fn(0,'Y','S')
CREATE FUNCTION [dbo].[Fill_AccVrType_Fn]
(	
	@Cmp_Code		Int,
	@Default		Char(1),
	@DefaultType	Char(1)
)
RETURNS @AccVrType Table 
(
	VR_ID		Varchar(25),
	VR_TYPE		Varchar(50),
	VR_DEFAULT Char(1)
)
AS
BEGIN
	
	IF @Default = 'Y'
	Begin
		IF @DefaultType ='A' 
		Begin
			Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT)Values('','<<==ALL=>>','Y')
		End
		Else IF @DefaultType ='S' 
		Begin
			Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('','<<==SELECT=>>','Y')
		End
	End

	--Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('PRCH','Purchase','N')
	--Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('DEBITNOTE','Debit Note','N')
	--Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('SALE','Sale','N')
	--Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('CREDITNOTE','Credit Note','N')
	Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('RECEIPT','Receipt','N')
	Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('PAYMENT','Payment','N')
	Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('CONTRA','Contra','N')
	Insert Into @AccVrType(VR_ID,VR_TYPE,VR_DEFAULT) Values('JOURNAL','Journal','N')

	IF @Default = 'N' UPDATE @AccVrType Set VR_DEFAULT = 'Y' WHERE VR_ID = 'PAYMENT'
    Return
END

