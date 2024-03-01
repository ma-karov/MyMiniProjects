<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title> Document </title> 
    <link rel = "stylesheet" href = "https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" /> 
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

    <form action = "{{ route('Home-Response') }}" method = "POST" enctype = "multipart/form-data" > 
        @csrf
        <div class = "form-group" > 
            <label for = "ID_Name" > Введите имя: </label> 
            <input id = "ID_Name" name = "Name" value = "{{ old('Name') }}" class = "form-control" /> 
        </div> <br> 
        <div class = "form-group" > 
            <label for = "ID_Telephone" > Введите номер телефона: </label> 
            <input type = "tel" id = "ID_Telephone" name = "Telephone" placeholder = "+7(777)777-77-77" class = "form-control" /> 
        </div> <br> 
        <div class = "form-group" > 
            <label for = "ID_Order" > Введите заказ: </label> 
            <input id = "ID_Order" name = "Order" value = "{{ old('Order') }}" class = "form-control" /> 
        </div> <br> 
        <input type = "hidden" name = "InputHidden" value = "test" />  
        <button> Заказать </button> 
    </form> 
        
    
</body>
</html>