using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(13, "Add attributes to attributes table")]
public class AddAttributes : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"
	
	INSERT INTO attributes (product_id, title, value)
	VALUES ('1', 'Вставка', 'бриллиант');

	INSERT INTO attributes (product_id, title, value)
	VALUES ('1', 'Для кого', 'Для женщин');


";

    protected override string GetDownSql(IServiceProvider services) => @"
	DELETE FROM attributes;
";
}
