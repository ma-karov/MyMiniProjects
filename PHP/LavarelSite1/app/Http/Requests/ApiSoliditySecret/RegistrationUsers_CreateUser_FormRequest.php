<?php

namespace App\Http\Requests\ApiSoliditySecret;

class RegistrationUsers_CreateUser_FormRequest extends \App\Http\Requests\ApiSoliditySecret\RegistrationUsers_BaseParent_FormRequest
{

    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    function authorize(): bool
    {
        return parent::authorize();
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array
     */
    function rules(): array
    {
        return [];
        return [
            "CreateUser.UserName" => "required",
            "CreateUser.EmailAddress" => "required",
            "CreateUser.Password" => "required"
        ];
    }

    /**
     * Prepare the data for validation.
     *
     * @return void
     */
    protected function prepareForValidation(): void
    {
        $this->merge( [ 'CreateUser' => new \App\Http\Forms\ApiSoliditySecret\RegistrationUsers_JobWithFormatingUser_Form( $this->FormatingFieldsToArray($this->CreateUser) ) ] );
    }

}
