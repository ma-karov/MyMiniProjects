<?php

class CreateRegistrationUsersAndRegistrationGroupRolesAndRegistrationUsersContactInfornmationsAndRegistrationUsersImagesAlbumsTable extends \Illuminate\Database\Migrations\Migration
{
    // '_registration_users_and_registration_group_roles_and_registration_users_contact_infornmations_and_registration_users_images_albums_'

    private const REGISTRATION_USERS_CONTACT_INFORMATIONS_TABLE = "RegistrationUsers_ContactInformations",
        REGISTRATION_USERS_TABLE = "RegistrationUsers";

    private function CreateRegistrationUsersTable(\Illuminate\Database\Schema\Blueprint $BluePrintRegistrationUsersTable)
    {
        //$BluePrintRegistrationUsersTable->addColumn("smallInteger", "ID", array( "autoIncrement" => true, "unsigned" => true, "primary" => true ) );
        $BluePrintRegistrationUsersTable->addColumn("smallInteger", "ID", array( "unsigned" => true, "autoIncrement" => true ) );
        $BluePrintRegistrationUsersTable->timestamps();

        //$BluePrintRegistrationUsersTable->string("E_MailAddress", 50)->unique();
        $BluePrintRegistrationUsersTable->addColumn('string', "E_MailAddress", array( 'length' => 50, "unique" => true ) );
        //$BluePrintRegistrationUsersTable->unique("string", "E_MailAddress");
        $BluePrintRegistrationUsersTable->addColumn("text", "HashPassword", array( "length" => 65000 ));
        $BluePrintRegistrationUsersTable->addColumn("boolean", "RegistrationConfirmation", array( "default" => "0" ) );

        $BluePrintRegistrationUsersTable->addColumn("boolean", "ActiveBool", array( "default" => "1" ) );
    }

    private function CreateRegistrationUsersContactInformationsTable(\Illuminate\Database\Schema\Blueprint $BluePrintRegistrationUsersContactInformationsTable)
    {
        $BluePrintRegistrationUsersContactInformationsTable->addColumn("smallInteger", "ID", array( "autoIncrement" => true, "unsigned" => true ) );
        //$BluePrintRegistrationUsersContactInformationsTable->indexCommand('primary', "smallInteger", "ID");
        $BluePrintRegistrationUsersContactInformationsTable->timestamps();

        $BluePrintRegistrationUsersContactInformationsTable->addColumn("string", "Surname", array( 'length' => 50 ) );
        $BluePrintRegistrationUsersContactInformationsTable->addColumn("string", "Name", array( 'length' => 30 ) );
        $BluePrintRegistrationUsersContactInformationsTable->addColumn("boolean", "MaleBool");

        $BluePrintRegistrationUsersContactInformationsTable->addColumn("smallInteger", "RegistrationUser_ID", array( "unsigned" => true ) );
        #$BluePrintRegistrationUsersContactInformationsTable->foreign("RegistrationUser_ID")->references("ID")->on(self::REGISTRATION_USERS_TABLE)->onDelete("cascade");

    }

    function up(): void
    {
        \Illuminate\Support\Facades\Schema::create(self::REGISTRATION_USERS_TABLE, function (\Illuminate\Database\Schema\Blueprint $BluePrintTable)
        {
            $this->CreateRegistrationUsersTable($BluePrintTable);
        } );

        /*\Illuminate\Support\Facades\Schema::create(self::REGISTRATION_USERS_CONTACT_INFORMATIONS_TABLE, function (\Illuminate\Database\Schema\Blueprint $BluePrintTable)
        {
            $this->CreateRegistrationUsersContactInformationsTable($BluePrintTable);
        } );*/

        /*\Illuminate\Support\Facades\Schema::create(self::REGISTRATION_USERS_TABLE, function (\Illuminate\Database\Schema\Blueprint $BluePrintTable)
        {
            $this->CreateRegistrationUsersTable($BluePrintTable);
            $this->CreateRegistrationUsersContactInformationsTable($BluePrintTable);

        } );*/
    }

    function down(): void
    {
        \Illuminate\Support\Facades\Schema::dropIfExists(self::REGISTRATION_USERS_TABLE);
        \Illuminate\Support\Facades\Schema::dropIfExists(self::REGISTRATION_USERS_CONTACT_INFORMATIONS_TABLE);
    }
}
