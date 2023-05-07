using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(12, "Attributes Table")]
public class AttributesTable : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"
	create table attributes(

	id bigint generated by default as identity
		constraint pk_attributes
		primary key,
	product_id bigint not null
		constraint fk_attributes__products_id
		references products
        on delete cascade,
	value text not null,
	title text not null
);
";

    protected override string GetDownSql(IServiceProvider services) => @"
	drop table if exists attributes;
";
}
