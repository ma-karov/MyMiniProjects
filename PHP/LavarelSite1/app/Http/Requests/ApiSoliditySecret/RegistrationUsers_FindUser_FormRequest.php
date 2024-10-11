<?php

namespace App\Http\Requests\ApiSoliditySecret;

class RegistrationUsers_FindUser_FormRequest extends \App\Http\Requests\ApiSoliditySecret\RegistrationUsers_BaseParent_FormRequest
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
    public function rules(): array
    {
        return [];
    }

    /**
     * Prepare the data for validation.
     *
     * @return void
     */
    protected function prepareForValidation(): void
    {
        //$this->merge( [ 'FindUser' => $this->FormatingFieldsToArray($this->FindUser) ] );
        $this->merge( [ 'FindUser' => new \App\Http\Forms\ApiSoliditySecret\RegistrationUsers_JobWithFormatingUser_Form($this->FormatingFieldsToArray($this->FindUser)) ] );
    }

}
