using System.Data;
using Migrator.Framework;

namespace Tenis.Migrations
{
	[Migration(20080401110402)]
	public class CreateUserTable_001 : Migration
	{
		public override void Up()
		{
			Database.AddTable("User",
							new Column("UserId", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
							new Column("Username", DbType.AnsiString, 25)
							);
		}

		public override void Down()
		{
			Database.RemoveTable("User");
		}
	}
}