<?php

namespace App\Http\Requests\AuthenticateUsers;


class PrivateAccountFormRequest extends \Illuminate\Foundation\Http\FormRequest
{
    public function authorize(): bool
    {
        return true;
    }

    public function rules(): array
    {
        return array(
            "Name" => "required",
            "Surname" => "required",
            "EmailAddress" => "required",
            "Password" => "required",
            "RepeatPassword" => [ "required", new Rules\ComparePasswordValidateRule($this->post("Password")) ]
        );
    }
}
