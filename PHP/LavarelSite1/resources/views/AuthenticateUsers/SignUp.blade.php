<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title> Document </title>
    <link rel = "stylesheet" href = "" />
</head>
<body>
    @if ($errors->any())
        <div class = "alert alert-danger" >
            <ul>
                @foreach ($errors->all() as $Error)
                    <li> {{ $Error }} </li>
                @endforeach
            </ul>
        </div>
    @endif

    <form action = "{{ route('AuthenticateUsers-PrivateAccount') }}" method = "POST" enctype = "multipart/form-data" >
        @csrf
        <div class = "form-group" >
            <label for = "ID_Name" > Введите имя: </label>
            <input id = "ID_Name" name = "Name" value = "{{ old('Name') }}" placeholder = "Иван" class = "form-control" />
        </div> <br>
        <div class = "form-group" >
            <label for = "ID_Surname" > Введите фамилию: </label>
            <input id = "ID_Surname" name = "Surname" value = "{{ old('Surname') }}" placeholder = "Иванов" class = "form-control" />
        </div> <br>
        <div class = "form-group" >
            <label for = "ID_EmailAddress" > Введите email: </label>
            <input type = "email" id = "ID_EmailAddress" name = "EmailAddress" placeholder = "ya@yandex.ru" class = "form-control" />
        </div> <br>
        <div class = "form-group" >
            <label for = "ID_Password" > Введите пароль: </label>
            <input type = "password" id = "ID_Password" name = "Password" value = "{{ old('Password') }}" class = "form-control" />
        </div> <br>
        <div class = "form-group" >
            <label for = "ID_RepeatPassword" > Повторите пароль: </label>
            <input type = "password" id = "ID_RepeatPassword" name = "RepeatPassword" value = "{{ old('RepeatPassword') }}" class = "form-control" />
        </div> <br>

        <button> Зарегистрироваться </button>
    </form>

</body>
</html>
