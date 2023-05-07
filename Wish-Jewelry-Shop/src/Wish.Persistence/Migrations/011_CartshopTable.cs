using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(11, "Orders Table")]
public class OrdersTable : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"
	create table cartshop(

	id bigint generated by default as identity
		constraint pk_orders
		primary key,
	user_id bigint not null
		constraint fk_orders__identity_users_id
		references identity_users
		on delete cascade,
	product_id bigint not null
		constraint fk_orders__products_id
		references products
		on delete cascade,
	count bigint not null,
	price decimal not null,
	status bigint not null,
	created_datetime timestamp with time zone
	
)";
	

    protected override string GetDownSql(IServiceProvider services) => @"
	drop table if exists cartshop;
";
}
