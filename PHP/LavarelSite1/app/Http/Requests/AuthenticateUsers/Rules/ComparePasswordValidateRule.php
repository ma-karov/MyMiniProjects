<?php

namespace App\Http\Requests\AuthenticateUsers\Rules;

class ComparePasswordValidateRule implements \Illuminate\Contracts\Validation\Rule
{
    private $Password, $RepeatPassword, $attr;
    public function __construct(string $Password)
    {
        $this->Password = $Password;
    }

    public function passes($attribute, $value): bool
    {
        $this->attr = $attribute;
        $this->RepeatPassword = $value;
        return ( $this->Password == $value );
    }

    public function message(): string
    {
        return "The validation error message. $this->Password == $this->RepeatPassword: $this->attr";
    }
}
