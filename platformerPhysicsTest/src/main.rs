fn main() {
    App::new()
      .add_plugins(DefaultPlugins.set(WindowPlugin {
        primary_window: Some(Window {
          mode: WindowMode::Fullscreen,
          ..default()
        }),
        ..default()
      }))
      .add_startup_system(setup_system)
      .add_system(hello_world_system)
      .run();
  }
  
  fn setup_system() {
    println!("Welcome to ferris spin!");
  }
  
  fn hello_world_system() {
    println!("hello world");
  }