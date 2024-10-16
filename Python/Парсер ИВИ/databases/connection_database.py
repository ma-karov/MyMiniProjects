import os; 
import sqlalchemy, sqlalchemy.orm; 

os.chdir(os.path.dirname(__file__)) 
SQLALCHEMY_DATABASE_URL = "sqlite:///./sql_app.db"
 
engine = sqlalchemy.create_engine(
    SQLALCHEMY_DATABASE_URL, connect_args={"check_same_thread": False}
)


class BaseModelsORM(sqlalchemy.orm.DeclarativeBase): pass
 
class Movie(BaseModelsORM):
    __tablename__ = "Movies"
 
    id = sqlalchemy.Column(sqlalchemy.Integer, primary_key=True, index=True)
    appelation = sqlalchemy.Column(sqlalchemy.String)
    director_fio = sqlalchemy.Column(sqlalchemy.String) 
    create_year = sqlalchemy.Column(sqlalchemy.String)
    style = sqlalchemy.Column(sqlalchemy.String) 
    raiting = sqlalchemy.Column(sqlalchemy.Float) 

BaseModelsORM.metadata.create_all(bind=engine)

connection_database = sqlalchemy.orm.sessionmaker(autoflush=False, bind=engine)()
