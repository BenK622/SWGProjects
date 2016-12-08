Select * 
from Reservations
join Customers
on Customers.CustomerID = Reservations.CustomerID 
join Locations
on Locations.LocationId = Reservations.LocationID

/* Itemize bill */
Select CustomerFirstName, CheckInDate, CheckOutDate, RoomName, RoomTypes.BaseRate, States.TaxRate, SeasonRate
from Reservations
join Customers
on Customers.CustomerID = Reservations.CustomerID 
join ReservationRooms
on ReservationRooms.ReservationID = Reservations.ReservationID
join Rooms
on ReservationRooms.RoomID = Rooms.RoomID
join RoomTypes
on Rooms.RoomTypeID = RoomTypes.RoomTypeID
join Locations
on Reservations.LocationID = Locations.LocationId
join States
on States.StateID = Locations.StateID
join Seasons 
on Seasons.SeasonID = Reservations.SeasonID

/* Get any amenitys orderd */
Select CustomerFirstName, CustomerLastName, AmenityName, AmenityCost, CheckInDate, CheckOutDate
from Reservations
join Customers
on Customers.CustomerID = Reservations.CustomerID
join SelectedAmenities 
on SelectedAmenities.ReservationID = Reservations.ReservationID
join Amenity 
on SelectedAmenities.AmenityID = Amenity.AmenityID

/* how many reservations in a month? */
Select *
from Reservations
where Month(CheckInDate) = 12  And YEAR(CheckInDate) = 2016

/* reservations by broker */
Select ReservationID,BrokerName,BrokerCommissionRate
from Reservations 
join Brokers
on Brokers.BrokerID = Reservations.BrokerID


/* how many reservations part of a group 