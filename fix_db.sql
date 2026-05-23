SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO
DECLARE @ConstraintName nvarchar(200);

-- Find UNIQUE CONSTRAINT on MaTaiKhoan
SELECT @ConstraintName = kc.name
FROM sys.key_constraints kc
JOIN sys.index_columns ic ON kc.parent_object_id = ic.object_id AND kc.unique_index_id = ic.index_id
JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE kc.type = 'UQ' AND kc.parent_object_id = OBJECT_ID('NhanVien') AND c.name = 'MaTaiKhoan';

IF @ConstraintName IS NOT NULL
BEGIN
    DECLARE @SQL nvarchar(1000) = 'ALTER TABLE NhanVien DROP CONSTRAINT [' + @ConstraintName + ']';
    EXEC sp_executesql @SQL;
    PRINT 'Dropped constraint: ' + @ConstraintName;
END
ELSE
BEGIN
    -- Maybe it's a unique index
    SELECT @ConstraintName = i.name
    FROM sys.indexes i
    JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
    WHERE i.object_id = OBJECT_ID('NhanVien') AND i.is_unique = 1 AND c.name = 'MaTaiKhoan' AND i.is_primary_key = 0;
    
    IF @ConstraintName IS NOT NULL
    BEGIN
        DECLARE @SQL2 nvarchar(1000) = 'DROP INDEX [' + @ConstraintName + '] ON NhanVien';
        EXEC sp_executesql @SQL2;
        PRINT 'Dropped index: ' + @ConstraintName;
    END
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID('NhanVien') AND name = 'UQ_NhanVien_MaTaiKhoan')
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX UQ_NhanVien_MaTaiKhoan
    ON NhanVien(MaTaiKhoan)
    WHERE MaTaiKhoan IS NOT NULL;
    PRINT 'Created filtered index UQ_NhanVien_MaTaiKhoan';
END
GO
