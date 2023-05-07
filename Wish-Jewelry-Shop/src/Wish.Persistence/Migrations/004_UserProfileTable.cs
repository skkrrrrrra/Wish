using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(4, "User profile table")]
public class UserProfileTable : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"

create table user_profiles (

	 id bigint not null
        constraint fk_user_profiles_id__identity_users_user_id
            references identity_users
            on delete cascade,
	
    full_name text not null,
    status     integer not null default 0,
    username   text unique not null,
    constraint pk_user_profiles
        primary key (id)
);
";

    protected override string GetDownSql(IServiceProvider services) => @"
drop table if exists user_profiles;";

} 
