<nav class="navbar navbar-static-top">
    <!-- Sidebar toggle button-->
    <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
    </a>

    <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
            <!-- Messages: style can be found in dropdown.less-->



            <!-- User Account: style can be found in dropdown.less -->
            <li class="dropdown user user-menu">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">

                    <span class="hidden-xs">{{ Auth::user()->name}}</span>
                </a>
                <ul class="dropdown-menu">
                    <!-- User image -->
                    <li class="user-header">


                        <p>
                            {{ Auth::user()->name}}

                        </p>
                    </li>

                    <!-- Menu Footer-->
                    <li class="user-footer">

                        <div class="pull-right">
                            <a href="{{ url('logout')}}" class="btn btn-default btn-flat">Sign out</a>
                        </div>
                    </li>
                </ul>
            </li>
            <!-- Control Sidebar Toggle Button -->
            <li>
                <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
            </li>
        </ul>
    </div>
</nav>

<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
        <!-- Sidebar user panel -->
        <div class="user-panel">
            <div class="pull-left info">
                <p>{{ Auth::user()->name}}</p>
                <!-- <a href="#"><i class="fa fa-circle text-success"></i> Online</a> -->
            </div>
            <div class="pull-left image">
                <img src="dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
            </div>

        </div>

        <!-- /.search form -->
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class="sidebar-menu" data-widget="tree">
            <li class="header">MAIN NAVIGATION</li>

            @if(Auth::user()->usertype == 1)
            <li class="{{ 'admin/dashboard' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('admin/dashboard')}}">
                    <i class="fa fa-home"></i> <span>Dashboard
                    </span>

                </a>
            </li>
            <li class="{{ 'admin/admin/list' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('admin/admin/list')}}">
                    <i class="fa fa-user"></i> <span>Users</span>
                </a>
            </li>

            <li class="{{ 'admin/group/list' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('admin/group/list')}}">
                    <i class="ion ion-person-stalker"></i> <span>Groups</span>
                </a>
            </li>

            <li class="{{ 'admin/course/list' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('admin/course/list')}}">
                    <i class="fas fa-calendar-alt"></i>
                    <span>Course</span>
                </a>
            </li>

            <li class="{{ 'admin/room/list' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('admin/room/list')}}">
                    <i class="fas fa-calendar-alt"></i>
                    <span>Room</span>
                </a>
            </li>

            <li class=" {{ 'admin/schedule/list' == request()->path() ? 'active' : ''}}">
                <a href="{{ url('admin/schedule/list')}}">
                    <i class="fas fa-calendar-alt"></i>
                    <span>Schedules</span>
                </a>
            </li>
            <li class=" {{ 'admin/timeTable/list' == request()->path() ? 'active' : ''}}">
                <a href="{{ url('admin/timeTable/list')}}">
                    <i class="fas fa-calendar-alt"></i>
                    <span>Time Table</span>
                </a>
            </li>

            @elseif(Auth::user()->usertype == 2)
            <li class="{{ 'teacher/dashboard' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('teacher/dashboard')}}">
                    <i class="fa fa-home"></i> <span>User Profile</span>

                </a>
            </li>

            <li class="{{ 'teacher/timeTable/list' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('teacher/timeTable/list')}} ">
                    <i class="fas fa-calendar-alt"></i>
                    <span>Schedules</span>
                </a>
            </li>

            @elseif(Auth::user()->usertype == 3)
            <li class="{{ 'student/dashboard' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('student/dashboard')}}">
                    <i class="fa fa-home"></i> <span>User Profile</span>

                </a>
            </li>

            <li class=" {{ 'student/timeTable/list' == request()->path() ? 'active' : ''}}">
                <a href="{{ url('student/timeTable/list')}}">
                    <i class="fas fa-calendar-alt"></i>
                    <span>Schedules</span>
                </a>
            </li>
            @endif


            <li class="{{ 'logout' == request()->path() ? 'active' : ''}} ">
                <a href="{{ url('logout')}}">
                    <i class="ion ion-log-out"></i> <span>Logout</span>
                </a>
            </li>
        </ul>
    </section>
    <!-- /.sidebar -->
</aside>
