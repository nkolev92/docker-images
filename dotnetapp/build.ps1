function Log {
    Param ([string] $s)
    Write-Output "###### $s"
}

function Check {
    Param ([string] $str)
    if ($LASTEXITCODE -ne 0) { 
        Log "Failed: $str"
        throw "Error case -- see failed step"
    }
}

function BuildDockerImage {
    Param ([string] $file,
           [string] $image
           )
    Log "Build the docker image $image"
    docker build --pull -t $image -f $file .
    Check "docker build $image"
    Log "Docker image built: $image"
}

### Build the docker image. 

BuildDockerImage -file "Dockerfile" -image "dotnetapp"