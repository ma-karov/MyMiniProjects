<?php

namespace App\Http\Models;

class RegistrationUsers_ContactInformationsModel extends \Illuminate\Database\Eloquent\Model
{
    const TABLE_NAME = "RegistrationUsers_ContactInformations";

    protected $table = self::TABLE_NAME,
              $primaryKey = "ID",
              $fillable = array( "Surname", "Name", "MaleBool" );

    /*public static function Create(array $Array)
    {
        $RegistrationUserModel = RegistrationUsersModel::create( $Array[RegistrationUsersModel::TABLE_NAME] );
        return self::create(
            array(
                "Surname" => $Array[self::TABLE_NAME]["Surname"],
                "Name" => $Array[self::TABLE_NAME]["Name"],
                "MaleBool" => $Array[self::TABLE_NAME]["MaleBool"],
                "RegistrationUser_ID" => $RegistrationUserModel->ID
            ) );
    }*/


}
