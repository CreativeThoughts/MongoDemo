using System;

namespace MongoDemo.Model
{
    public class Settings
    {
        //Kerberos -- mongodb://username%40REALM.com@myserver/?authMechanism=GSSAPI&authMechanismProperties=SERVICE_NAME:othername
        //LDAP ----mongodb://username:password@myserver/?authSource=$external&authMechanism=PLAIN
        // using the replica set (?connect=replicaset)
        // read preference -- mongodb://server2/?connect=direct;readpreference=nearest
        public string ConnectionString;
        public string Database;
    }
}
