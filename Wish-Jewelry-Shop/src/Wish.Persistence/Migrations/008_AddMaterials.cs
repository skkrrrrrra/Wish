using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(8, "Add materials to matherials table")]
public class AddMaterials : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"
	
	INSERT INTO materials (id, type, title)
	VALUES ('1', '0', 'Золото');

	INSERT INTO materials (id, type, title)
	VALUES ('2', '1', 'Серебро');

	INSERT INTO materials (id, type, title)
	VALUES ('3', '2', 'Платина');


";

    protected override string GetDownSql(IServiceProvider services) => @"
	DELETE FROM materials;
";
}
