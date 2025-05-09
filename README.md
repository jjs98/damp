# damp
Docs About Managed Projects

## project json
```json
{
  "name": "Test1",
  "description": "this is a test",
  "hostedEnvironments": [
    {
      "url": "https://prod.test.de",
      "environment": "prod",
      "description": "This is for prod",
      "databaseConnections": [
        {
          "databaseServer": "test.db",
          "database": "tst_DB",
          "user": "test_user"
        }
      ]
    },
    {
      "url": "https://dev.test.de",
      "environment": "dev",
      "description": "This is for dev",
      "databaseConnections": [
        {
          "databaseServer": "prod.db",
          "database": "prd_DB",
          "user": "prod_user"
        }
      ]
    }
  ],
  "dependencies": [2, 3],
  "tags": ["test"]
}
```

## Outcome

# Test1
1. [Description](#description)
2. [Hosted Environments](#hosted-environments)
    - [prod](#prod)
    - [dev](#dev)
3. [Dependencies](#dependencies)
4. [Tags](#tags)
## <div name="description" /> Description
this is a test
## <div name="hosted-environments" /> Hosted Environments
### <div name="prod" /> prod
https://prod.test.de

This is for prod
#### Database Connections
- Server: test.db
- Database: tst_DB
- User: test_user
### <div name="dev" /> dev
https://dev.test.de

This is for dev
#### Database Connections
- Server: prod.db
- Database: prd_DB
- User: prod_user
## <div name="dependencies" /> Dependencies
2, 3
## <div name="tags" /> Tags
test
