---------------------------------------------------
-- To use this script, create a database with GraphVizDB 
-- and update the connection string in console and web 
-- application to point to this address
---------------------------------------------------

CREATE TABLE [dbo].[Edge] (
    [SourceId] INT NOT NULL,
    [TargetId] INT NOT NULL
);

GO
CREATE TABLE [dbo].[Node] (
    [Id]   INT          NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
ALTER TABLE [dbo].[Edge]
    ADD CONSTRAINT [FK_EdgeSource_ToNode] FOREIGN KEY ([SourceId]) REFERENCES [dbo].[Node] ([Id]);

GO
ALTER TABLE [dbo].[Edge]
    ADD CONSTRAINT [FK_EdgeTarget_ToNode] FOREIGN KEY ([TargetId]) REFERENCES [dbo].[Node] ([Id]);

GO
ALTER TABLE [dbo].[Edge]
    ADD CONSTRAINT [PK_Edge] PRIMARY KEY CLUSTERED ([SourceId] ASC, [TargetId] ASC);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Node_Name]
    ON [dbo].[Node]([Name] ASC);

GO
