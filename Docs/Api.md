# Login

```
POST {{host}}/auth/login
```

### Login Request

```json
{
  "email": "abc123@zzz.com",
  "password": "Test@123"
}
```

```js
200 OK
```

### Login Response

```json
{
  "id": "6387c649-1a8f-4655-9886-75f2fa250de1",
  "firstName": "Tom",
  "lastName": "Hardy",
  "email": "abc123@zzz.com",
  "password": "Test@123"
}
```

```js
200 OK
```
