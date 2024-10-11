@extends('layouts.app')

@section('content')


<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            TEACHER PROFILE

    </section>

    <!-- Main content -->
    <section class="content" style="padding-top: 100px; background-color: white;">
        <div class="container py-5">

            <div class="row">
                <div class="col" style="font-size: medium;">
                    <nav aria-label="breadcrumb" class="bg-body-tertiary rounded-3 p-3 mb-4">
                        <ol class="breadcrumb mb-0">
                            <li class="breadcrumb-item active" aria-current="page">User Profile</li>
                        </ol>
                    </nav>
                </div>
            </div>

            <div class="col-lg-8">
                <div class="card mb-4">
                    <div class="card-body" style="font-size: medium;">
                        <div class="row">
                            <div class="col-sm-3">
                                <p class="mb-0">FULL NAME</p>
                            </div>
                            <div class="col-sm-9">
                                <p class="text-muted mb-0"> {{ Auth::user()->name}}</p>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-sm-3">
                                <p class="mb-0">EMAIL</p>
                            </div>
                            <div class="col-sm-9">
                                <p class="text-muted mb-0"> {{ Auth::user()->email}}</p>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-sm-3">
                                <p class="mb-0">STATUS</p>
                            </div>
                            <div class="col-sm-9">
                                <p class="text-muted mb-0">TEACHER</p>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-sm-3">
                                <p class="mb-0">Address</p>
                            </div>
                            <div class="col-sm-9">
                                <p class="text-muted mb-0">Bay Area, San Francisco, CA</p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
</div>



</section>
<!-- /.content -->


</div>

@endsection