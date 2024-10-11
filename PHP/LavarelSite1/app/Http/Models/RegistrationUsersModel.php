<?php

namespace App\Http\Models;

class RegistrationUsersModel extends \Illuminate\Database\Eloquent\Model
{
    const TABLE_NAME = "RegistrationUsers";

    protected $table = self::TABLE_NAME,
        $primaryKey = "ID",
        $fillable = [ "E_MailAddress", "HashPassword" ];

}

