using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(7, "Add categories to categories table")]
public class AddCategories : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"
	
	INSERT INTO categories (title) VALUES ('Rings');
	INSERT INTO categories (title) VALUES ('Earrings');
	INSERT INTO categories (title) VALUES ('Armlets');
	INSERT INTO categories (title) VALUES ('Necklaces');

";

    protected override string GetDownSql(IServiceProvider services) => @"
	drop table if exists attributes;
";
}
