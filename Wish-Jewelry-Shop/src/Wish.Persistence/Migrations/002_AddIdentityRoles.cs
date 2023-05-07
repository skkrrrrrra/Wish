using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(2, "Add identity roles to table")]
public class AddIdentityRoles : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"
INSERT INTO identity_roles (name, normalized_name, concurrency_stamp)
    VALUES ('Admin', 'ADMIN', '79e6dbdb-ca80-4002-a3b9-2c123db5c55a');

INSERT INTO identity_roles (name, normalized_name, concurrency_stamp)
    VALUES ('User', 'USER', 'f323dd28-f0e1-42f2-a334-84be0c5874c5');
";

	protected override string GetDownSql(IServiceProvider services) => @"
DELETE FROM identity_roles WHERE name in ('Admin', 'User');
";
}
