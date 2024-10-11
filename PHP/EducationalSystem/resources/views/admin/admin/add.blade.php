@extends('layouts.app')

@section('content')


<div class="content-wrapper">

    <section class="content-header">

        <h1>
            Add New Admin
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
                                <label>Full Name *</label>
                                <input type="text" class="form-control" name="name" required placeholder="Enter Full Name">
                            </div>
                            <div class="form-group">
                                <label>Email *</label>
                                <input type="email" class="form-control" name="email" required placeholder="Enter email">
                            </div>
                            <div class="form-group">
                                <label>Password *</label>
                                <input type="password" class="form-control" name="password" required placeholder="Password">
                            </div>

                            <div class="form-group">
                                <label>User Type *</label>
                                <select class="form-control" name="usertype" required>
                                    <option selected>Choose...</option>
                                    <option value="1">Admin</option>
                                    <option value="2">Teacher</option>
                                    <option value="3">Student</option>
                                </select>
                            </div>

                            <div class="form-group">
                                <label>Group *</label>
                                <select class="form-control" name="group_name" required>
                                    <option value="" disabled selected>Choose...</option>
                                    @foreach ($getGroupAll as $group)
                                    <option value="{{ $group->title }}">
                                        {{ $group->title }}
                                    </option>
                                    @endforeach
                                </select>
                                <p>If user is student select his/ her group Or Don't select any group</p>
                            </div>


                        </div>


                        <div class="box-footer">
                            <button type="submit" class="btn btn-primary">Save</button>
                            <a href="{{ url('admin/admin/list')}}" class="btn btn-danger">Back</a>
                        </div>
                    </form>
                </div>

    </section>

</div>

@endsection
