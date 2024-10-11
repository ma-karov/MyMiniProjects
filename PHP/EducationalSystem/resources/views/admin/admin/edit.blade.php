@extends('layouts.app')

@section('content')


<div class="content-wrapper">

    <section class="content-header">

        <h1>
            Edit Admin
        </h1>

    </section>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <!-- left column -->
            <div class="col-md-12">
                <!-- general form elements -->
                <div class="box box-primary">

                    <!-- /.box-header -->
                    <!-- form start -->
                    <form method="post" action="">
                        {{ csrf_field() }}
                        <div class="box-body">
                            <div class="form-group">
                                <label>Name</label>
                                <input type="text" class="form-control" name="name" value="{{ $getRecord->name}}" required placeholder="Enter name">
                            </div>
                            <div class="form-group">
                                <label>Email</label>
                                <input type="email" class="form-control" name="email" value="{{ $getRecord->email}}" required placeholder="Enter email">
                            </div>
                            <div class="form-group">
                                <label>Password</label>
                                <input type="text" class="form-control" name="password" placeholder="Password">
                                <p>Do you want to change password? Enter new password </p>
                            </div>

                            <div class="form-group">
                                <label>User Type</label>
                                <select class="form-control" name="usertype" required>
                                    <option value="{{ $getRecord->usertype}}" selected>
                                        @if($getRecord->usertype == 1)
                                        ADMIN
                                        @elseif($getRecord->usertype == 2)
                                        TEACHER
                                        @elseif($getRecord->usertype == 3)
                                        STUDENT
                                        @endif
                                    </option>
                                    <option value="1">Admin</option>
                                    <option value="2">Teacher</option>
                                    <option value="3">Student</option>
                                </select>
                            </div>
                            <!-- <div class="form-group">
                                <label>Group</label>
                                <input type="text" class="form-control" name="group" value="{{ $getRecord->group_name}}" placeholder="">

                            </div> -->


                            <div class="form-group">
                                <label>Group *</label>
                                <select class="form-control" name="group_name" >
                                    <option value="{{ $getRecord->group_name}}" selected>{{ $getRecord->group_name}}</option>
                                    @foreach ($getGroupAll as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                            </div>



                        </div>


                        <div class="box-footer">
                            <button type="submit" class="btn btn-primary">Update</button>

                            <a href="{{ url('admin/admin/list')}}" class="btn btn-danger">Back</a>
                        </div>
                    </form>
                </div>

    </section>
    <!-- /.content -->
</div>

@endsection
