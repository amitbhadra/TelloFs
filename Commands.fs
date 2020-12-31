namespace Tello
    module Commands = 
        // let sock = new UdpClient(receivePort)

        let sendCommand command = 
            printfn ">> send cmd: %s" command

        let takeoff = 
            sendCommand "takeoff"
        
        let setSpeed speed = 
            sendCommand ("speed " + speed)
         
        let rotatecw degrees = 
            sendCommand ("cw " + degrees)

        let rotateccw degress = 
            sendCommand ("ccw " + degress)
        
        let flip direction = 
            sendCommand ("flip " + direction)

        let comeDown = 
            sendCommand "land"
        
        let move direction distance =
            sendCommand (direction + " " + distance)

        let moveBack distance = 
            sendCommand ("back " + distance)
        
        let moveDown distance = 
            sendCommand ("down " + distance)
        
        let moveForward distance = 
            sendCommand ("forward" + distance)
        
        let moveLeft distance = 
            sendCommand ("left " + distance)

        let moveRight distance = 
            sendCommand ("right " + distance)
           
        let moveUp distance = 
            sendCommand ("up " + distance)
        