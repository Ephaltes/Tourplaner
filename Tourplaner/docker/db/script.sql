CREATE TABLE Route(
	id serial PRIMARY KEY,
	name text NOT NULL,
	origin text NOT NULL,
	destination text NOT NULL,
	description text,
	imagename text,
	directions text
);

CREATE TABLE Log(
	id serial PRIMARY KEY,
	startdate timestamp NOT NULL,
	enddate timestamp NOT NULL,
	origin text NOT NULL,
	destination text NOT NULL,
	distance double precision NOT NULL,
	rating double precision NOT NULL,
	note text,
	movementmode integer,
	mood integer,
	bpm integer,
	route_id integer,
	CONSTRAINT fk_route FOREIGN KEY (route_id) REFERENCES Route(id)
	ON DELETE CASCADE
);

INSERT INTO Route(name,origin,destination,description,imagename) VALUES('route1_test','origin_test','destination_test','description','placeholder.png');
INSERT INTO Route(name,origin,destination,description,imagename) VALUES('route2_test','origin2_test','destination2_test','description2','placeholder2.png');

INSERT INTO Log(startdate,enddate,origin,destination,distance,rating,note,movementmode,mood,bpm,duration,avgspeed,kcal,route_id) VALUES(NOW()- INTERVAL '1 DAY', NOW(),'log_orgin1','log_destination1',50.0,5.4,'note1',2,2,230,INTERVAL '1 DAY',54.33,500,1);
INSERT INTO Log(startdate,enddate,origin,destination,distance,rating,note,movementmode,mood,bpm,duration,avgspeed,kcal,route_id) VALUES(NOW()- INTERVAL '2 DAY', NOW() - INTERVAL '1 DAY','log_orgin2','log_destination2',50.0,5.4,'note1',2,2,230,INTERVAL '2 DAY',54.33,500,1);