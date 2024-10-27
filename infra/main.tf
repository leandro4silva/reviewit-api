provider "aws" {
  region                     = "sa-east-1"
  access_key                 = "test"  # Credenciais fictícias para LocalStack
  secret_key                 = "test"  # Credenciais fictícias para LocalStack
  skip_credentials_validation = true
  skip_requesting_account_id = true
  skip_metadata_api_check    = true

  endpoints {
    dynamodb = "http://localhost:4566"  # Endpoint do LocalStack para DynamoDB
  }
}

resource "aws_dynamodb_table" "basic-dynamodb-table" {
  name           = "User"
  billing_mode   = "PROVISIONED"
  read_capacity  = 20
  write_capacity = 20
  hash_key       = "Id"
  range_key      = "Email"

  attribute {
    name = "Id"
    type = "S"
  }

  attribute {
    name = "Email"
    type = "S"
  }

  attribute {
    name = "Name"
    type = "N"
  }

  ttl {
    enabled = false  # Se você não precisar de TTL, mantenha assim
  }

  global_secondary_index {
    name               = "UserEmailIndex"
    hash_key           = "Email"
    range_key          = "Name"
    write_capacity     = 10
    read_capacity      = 10
    projection_type    = "INCLUDE"
    non_key_attributes = ["Id"]
  }

  tags = {
    Name        = "dynamodb-table-1"
    Environment = "production"
  }
}