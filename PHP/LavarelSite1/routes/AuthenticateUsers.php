<?php

Route::get("AuthenticateUsers/SignUp/", "AuthenticateUsersController@SignUp" )->name("AuthenticateUsers-SignUp");

Route::post("AuthenticateUsers/PrivateAccount/", "AuthenticateUsersController@PrivateAccount" )->name("AuthenticateUsers-PrivateAccount");
