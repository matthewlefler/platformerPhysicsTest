// src/bin/server.rs
use std::os::unix::net::{UnixListener, UnixStream};

use anyhow::Context;

fn main() 
{
    println!("Hello, world!");
}

fn create_socket() -> anyhow::Result<()> 
{
    let socket_path = "mysocket";

    // copy-paste this and don't think about it anymore
    // it will be hidden from there on
    if std::fs::metadata(socket_path).is_ok() {
        println!("A socket is already present. Deleting...");
        std::fs::remove_file(socket_path).with_context(|| {
            format!("could not delete previous socket at {:?}", socket_path)
        })?;
    }

    let unix_listener =
        UnixListener::bind(socket_path).context("Could not create the unix socket")?;

    Ok(())
}
