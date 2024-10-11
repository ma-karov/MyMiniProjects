@extends('layouts.app')

@section('content')


<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">

        <div class="col-sm-6">
            <h1>
                Schedule List (Total : {{$getRecord->total()}})

            </h1>
        </div>
        <!-- <div class="col-sm-6" style="text-align: right;">
            <a href="{{ url('admin/schedule/add') }}" class="btn btn-primary">Add new Schedule</a>
        </div> -->
    </section>

    <section class="content-header">
        <div class="row">
            <!-- left column -->
            <div class="col-md-12">
                <!-- general form elements -->
                <div class="box box-primary">

                    <!-- /.box-header -->
                    <!-- form start -->
                    <form method="get" action="">

                        <div class="box-body">

                            <div class="box-header">
                                <h3 class="box-title">Search Schedule</h3>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-3">
                                    <label>Schedule Titel </label>
                                    <input type="text" class="form-control" name="name" value="{{Request::get('name')}}" placeholder="Enter Schedule Title">
                                </div>
                                <div class="form-group col-md-3">
                                    <label>Start Date </label>
                                    <input type="date" class="form-control" name="startDate" value="{{Request::get('startDate')}}" placeholder="Enter startDate">
                                </div>

                                <div class="form-group col-md-3">
                                    <label>End Date </label>
                                    <input type="date" class="form-control" name="endDate" value="{{Request::get('endDate')}}" placeholder="Enter startDate">
                                </div>
                                <div class="form-group col-md-3">
                                    <label>Group</label>
                                    <input type="text" class="form-control" name="group" value="{{Request::get('group')}}" placeholder="Group" >
                                </div>
                                <div class="form-group col-md-3">
                                    <label>Created Date </label>
                                    <input type="date" class="form-control" name="date" value="{{Request::get('date')}}" placeholder="">
                                </div>

                                <!-- <div class="form-group col-md-3">
                                    <label>Group</label>
                                    <input type="text" class="form-control" name="group" placeholder="Enter group" >
                                </div> -->
                                <div class="form-group col-md-3">
                                    <button class="btn btn-primary" type="submit" style="margin-top: 25px;">Search</button>
                                    <a href="{{ url('admin/schedule/list')}}" class="btn btn-success" type="submit" style="margin-top: 25px;">Reset</a>
                                    <a href="{{ url('admin/schedule/add') }}" class="btn btn-primary" style="margin-top: 25px;">Add new User</a>
                                </div>

                            </div>

                        </div>
                    </form>
                </div>
            </div>
        </div>

    </section>

    <!-- Main content -->
    <section class="content">
        <div class="row">

            <!-- /.col -->
            <div class="col-md-12">

                <div class="box">
                    @include('_message')
                    <div class="box-header">
                        <h3 class="box-title"> Schedule List</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <!-- <div class="form-group">
                            <input type="text" id="searchInput" class="form-control" onkeyup="searchTable()" placeholder="Search for room..">
                        </div> -->
                        <div class="table-responsive">
                            <table class="table table-striped responsive table-bordered" id="scheduleTable">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Title</th>
                                        <th>Start Date</th>
                                        <th>End Date</th>
                                        <th>Group</th>
                                        <th>Created Date</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @foreach($getRecord as $value)
                                    <tr>
                                        <td>{{$value->id}}</td>
                                        <td>{{$value->title}}</td>
                                        <td>{{ date('d-m-Y H:i A', strtotime($value->startDate))}}</td>
                                        <td>{{ date('d-m-Y H:i A', strtotime($value->endDate))}}</td>
                                        <td>{{$value->group_title}}</td>
                                        <td>{{ date('d-m-Y H:i A', strtotime($value->created_at))}}</td>
                                        <td>
                                            <a href="{{ url('admin/schedule/edit/'.$value->id) }}" class="btn btn-primary">Edit</a>
                                            <a href="{{ url('admin/schedule/delete/'.$value->id) }}" class="btn btn-danger">Delete</a>
                                            <!-- <a href="{{ url('admin/timeTable/list/'.$value->id) }}" class="btn btn-success">Add Time Table</a> -->
                                        </td>
                                    </tr>
                                    @endforeach
                                </tbody>

                            </table>
                            <div style="padding: 10px; text-align: right">
                                {!! $getRecord->appends(Illuminate\Support\Facades\Request::except('page'))->links()!!}
                            </div>
                        </div>
                        <!-- <nav>
                            <ul class="pagination">
                                <li class="page-item"><a class="page-link" href="#" onclick="prevPage()">Previous</a></li>
                                <li class="page-item"><a class="page-link" href="#" onclick="nextPage()">Next</a></li>
                            </ul>
                        </nav> -->
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

    </section>
    <!-- /.content -->
</div>

@endsection


@section('script')
<script>
    function searchTable() {
        // Declare variables
        var input, filter, table, tr, td, i, txtValue;
        input = document.getElementById("searchInput");
        filter = input.value.toUpperCase();
        table = document.getElementById("scheduleTable");
        tr
= table.getElementsByTagName("tr");

        // Loop through all table rows, and hide those who don't match the search query
        for (i = 1; i < tr.length; i++) { // Start from 1 to skip the table header row
            tr[i].style.display = "none"; // Hide the row initially
            td = tr[i].getElementsByTagName("td");
            for (var j = 0; j < td.length; j++) {
                if (td[j]) {
                    txtValue = td[j].textContent || td[j].innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                        break;
                    }
                }
            }
        }
    }

    const rowsPerPage = 10;
    let currentPage = 1;
    const table = document.getElementById("scheduleTable");
    const rows = table.getElementsByTagName("tbody")[0].getElementsByTagName("tr");

    function displayRows() {
        const start = (currentPage - 1) * rowsPerPage;
        const end = start + rowsPerPage;

        for (let i = 0; i < rows.length; i++) {
            rows[i].style.display = i >= start && i < end ? "" : "none";
        }
    }

    function nextPage() {
        if ((currentPage * rowsPerPage) < rows.length) {
            currentPage++;
            displayRows();
        }
    }

    function prevPage() {
        if (currentPage > 1) {
            currentPage--;
            displayRows();
        }
    }

    documen
    t.addEventListener("DOMContentLoaded", () => {
        displayRows();
    });
</script>

@endsection
