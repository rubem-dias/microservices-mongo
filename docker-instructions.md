# Creating Image from docker for use mongodb

*  Download mongo image from Docker Hub
   * <code> docker pull mongo </code>

* Create and execute mongo container
   * <code> docker run -d -p 27017:27017 --name catalog-mongo mongo </code>
   * run: create and init container.
   * -d: is the DETACHED mode, means that executing the container and second plan
   * -p 27017:27017: share the 27017 port from container to 27017 port from host (PC)
   * -name catalog-mongo: defines the container name.
   * mongo - image name to create container.

* Enter in container and execute
   * <code> docker exec -it catalog-mongo /bin/bash </code>

* Create and seed DB
   * <code>
       mongo or mongosh <br>
       show dbs <br>
       use ProductDb <br>
       db.createCollection('Products') <br>
       db.Products.insert or insertmany <br>
       db.Products.remove({}) <br>
       db.Products.find({}).pretty() //show items in prettier in cmd
     </code>
